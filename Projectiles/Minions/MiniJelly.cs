using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class MiniJelly : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mini Jelly");
			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		int Timer = Main.rand.Next(0, 120);
		int target = 0;
		int mode;
		int modeTimer;
		int wait;
		Vector2 important;
		public override void AI() {
			Timer++;
			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.MiniJelly>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.MiniJelly>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center + new Vector2(Main.rand.Next(-240, 240), Main.rand.Next(-240, 240));
			//special
			idlePosition.Y -= 100;

			float minionPositionOffsetX = 0f;//(10 + Projectile.minionPos * 40) * -player.direction;
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
			float distanceFromTarget = 700f;
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
						bool lineOfSight = true;//Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							target = i;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 8f;
			float inertia = 10f;
			if (foundTarget)
			{
				if (distanceFromTarget > 40f) {
					Vector2 direction = idlePosition - Projectile.Center; //targetCenter --> idlePosition
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 16f;
					inertia = 20f;
				}
				else {
					speed = 8f;
					inertia = 10f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = Main.rand.NextFloat(-1, 1);
					Projectile.velocity.Y = Main.rand.NextFloat(-1, 1);
				}
			}
            #endregion

            #region Projectile
			//Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 140;
			//if (Timer % 120 == 0 && foundTarget)
			//Projectile.NewProjectile(Projectile.Center, projDir, ProjectileType<MiniJellyLaser>(), Projectile.damage, Projectile.knockBack / 3, Main.myPlayer, target);

			#endregion

            #region Animation and visuals
            Projectile.rotation = Projectile.velocity.X * 0.05f;

			int frameSpeed = 5;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}

			Projectile.spriteDirection = player.direction;
            //Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
            #endregion

            #region Teleport
			if (foundTarget) {
				Projectile.velocity = new Vector2(0, 0);
				if (Main.npc[target].Center.X < Projectile.Center.X) Projectile.direction = 0;
				else Projectile.direction = 1;
				if (mode == 0) {
					Projectile.alpha += 15;
					if (Projectile.alpha >= 255)
						mode = 1;
				}
				else if (mode == 1) {
					important = Main.npc[target].Center + new Vector2(0, 200).RotatedByRandom(2);
					mode = 2;
				}
				else if (mode == 2) {
					Projectile.Center = important;
					Projectile.alpha -= 51;
					if (Projectile.alpha <= 0)
						mode = 3;
				}
				else if (mode == 3) {
					Projectile.Center = important;
					Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 140;
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ProjectileType<MiniJellyLaser>(), Projectile.damage, Projectile.knockBack / 3, Main.myPlayer, target, wait);
					mode = 4;
				}
				else if (mode == 4) {
					modeTimer++;
					if (modeTimer >= wait) {
						modeTimer = 0;
						mode = 0;
						wait -= 10;
						if (wait < 20) wait = 20;
					}
				}
			}
			else {
				mode = 0;
				Projectile.alpha = 0;
				wait = 60;
			}
            #endregion
        }
    }
}