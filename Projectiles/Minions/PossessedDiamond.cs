using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class PossessedDiamond : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
		}
		public override bool? CanCutTiles() {
			return Timer % 420 >= 240 && Projectile.friendly;
		}
		public override bool MinionContactDamage() {
			return Timer % 420 >= 240 && Projectile.friendly;
		}
		int Timer;
		Vector2 tempVar;
		public override void AI() {
			Timer++;
			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.PossessedDiamond>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.PossessedDiamond>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			//special
			idlePosition.Y -= 100;

			float minionPositionOffsetX = (32 + Projectile.minionPos * 32) * -player.direction;
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
			float distanceFromTarget = 900f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 1000f)
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
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height) || Timer % 420 >= 240; //To prevent weird re-targeting bugs, always see through walls when dashing.
						bool closeThroughWall = between < 150f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			if (foundTarget) Timer++;
			else Timer = 0;
			#endregion

			#region Movement

			float speed = 12f;
			float inertia = 40f;
			if (foundTarget)
			{
				//Shoot and dash are switched for the other if else, be careful!
				if (Timer % 420 < 240) { //Shoot mode
					//if (distanceFromTarget > 40f) {
						Vector2 direction = targetCenter - Projectile.Center;
						direction.Normalize();
						direction *= speed;
						Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
					//}
				}
				else { //Dash mode
					/*if (Timer % 30 == 1) tempVar = Projectile.DirectionTo(targetCenter)*50f;
					else tempVar *= 0.9f;
					Projectile.velocity = tempVar;*/
                }
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 24f;
					inertia = 10f;
				}
				else {
					speed = 15f;
					inertia = 30f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
            #endregion

            #region Animation and visuals + chase proj
            Projectile.rotation = Projectile.velocity.X * 0.05f; //Currently no target

			if (foundTarget) {
				if (Timer % 420 >= 240) { //Dash Mode
					if (Timer % 30 <= 1) tempVar = Vector2.Normalize(targetCenter-Projectile.Center)*25f;//Projectile.DirectionTo(targetCenter)*50f;
					else tempVar *= 0.9f;
					Projectile.velocity = tempVar;

					Projectile.rotation = Projectile.velocity.ToRotation(); // + MathHelper.PiOver2;
                }
				else { //Shoot mode
					Vector2 temp = Projectile.DirectionTo(targetCenter);
					Projectile.rotation = temp.ToRotation();

					if (Timer % 45 == 0) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, temp*12f, ProjectileType<PossessedDiamondProj>(), (int)(Projectile.damage*1.5f), Projectile.knockBack, Projectile.owner);
				}
				Projectile.rotation -= MathHelper.PiOver2;
            }
			#endregion
		}
	}
}