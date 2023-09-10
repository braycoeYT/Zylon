using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class DiskiteMinion_Center : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Desert Diskite");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 240;
		}
		public override bool? CanCutTiles() {
			return true;
		}
		public override bool MinionContactDamage() {
			return true;
		}
		bool init;
		public override void AI() {
			if (!init && Main.player[Projectile.owner].ownedProjectileCounts[ProjectileType<DiskiteMinion_CenterDeco>()] < Main.player[Projectile.owner].ownedProjectileCounts[Projectile.type]) {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(), ProjectileType<DiskiteMinion_CenterDeco>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI);
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(), ProjectileType<DiskiteMinion_SpikeRing>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI);
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(), ProjectileType<DiskiteMinion_LaserEye>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI);
				init = true;
            }

			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.DiskiteMinion>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.DiskiteMinion>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;

			float minionPositionOffsetX = (100 + Projectile.minionPos * 64) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) Projectile.velocity.X -= overlapVelocity;
					else Projectile.velocity.X += overlapVelocity;

					if (Projectile.position.Y < other.position.Y) Projectile.velocity.Y -= overlapVelocity;
					else Projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 400f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = true; //Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 10f;
			float inertia = 8f;

			if (foundTarget)
			{
				if (distanceFromTarget > 40f) {
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 15f;
					inertia = 12f;
				}
				else {
					speed = 10f;
					inertia = 8f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				/*else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}*/
			}
			#endregion

			#region Projectile
			//Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 40;
			//if (foundTarget)
			//{
			//	Timer++;
			//	if (Timer % 40 == rand)
			//	Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, projDir, ProjectileType<StardustBeam>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
			//}

			#endregion

			#region Animation and visuals
			//Projectile.rotation += 0.02f;

			//Lighting.AddLight(Projectile.Center, Color.DeepSkyBlue.ToVector3() * 0.64f);
			#endregion
		}
	}
}