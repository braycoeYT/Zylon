using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class Crackle : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 22;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		int Timer = Main.rand.Next(600);
		int mode;
		int randOffset = Main.rand.Next(120);
		public override void AI() {
			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.Crackle>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.Crackle>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;

			float minionPositionOffsetX = (60 + Projectile.minionPos * 40) * -player.direction;
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
			float distanceFromTarget = 575f;
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

					if (mode == 1) targetCenter -= new Vector2(0, 160); //For rain attack, go above the target
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
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;

							if (mode == 1) targetCenter -= new Vector2(0, 160); //For rain attack, go above the target
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 25f;
			float inertia = 30f;

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
					speed = 45f;
					inertia = 45f;
				}
				else {
					speed = 25f;
					inertia = 40f;
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

			#region Projectile
			if (foundTarget) Timer++;
			if (Timer % 600 < 300) mode = 0; //Thunder attack
			else mode = 1; //Rain attack

			if (Timer % 600 == 0) randOffset = Main.rand.Next(120);

			if (mode == 0 && foundTarget && Timer % 5 == 0 && Main.myPlayer == Projectile.owner) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileType<CrackleElectricity>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI, Timer+randOffset);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileType<CrackleElectricity>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI, Timer+60+randOffset);
			}
			else if (mode == 1 && foundTarget && Timer % 15 == 0 && Main.myPlayer == Projectile.owner) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-10, 11)-Projectile.width/2, 0), new Vector2(0, 20), ProjectileType<CrackleRain>(), Projectile.damage, Projectile.knockBack/2f, Projectile.owner);
			}
			/*Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 40;
			if (foundTarget && Vector2.Distance(targetCenter, Projectile.Center) < 80) {
				Timer++;
				if (Timer % 15 == 0)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ProjectileType<MeteorbProtect>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI);
			}*/

			#endregion

			#region Animation and visuals
			if (foundTarget && mode == 1) { //He is angy and looking down
				Projectile.frame = 2;
			}
			else {
				if (Math.Abs(Projectile.velocity.X) > Math.Abs(Projectile.velocity.Y)) { //Normal
					if (Projectile.velocity.X > 0) Projectile.frame = 1;
					else Projectile.frame = 3;
				}
				else {
					if (Projectile.velocity.Y > 0) Projectile.frame = 2;
					else Projectile.frame = 0;
				}
			}
			#endregion
		}
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RainCloud);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(0.5f, 1f);
			}
        }
    }
}