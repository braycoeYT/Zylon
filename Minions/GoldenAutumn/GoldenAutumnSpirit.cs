using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions.GoldenAutumn
{
	public class GoldenAutumnSpirit : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Autumn Spirit");
			Main.projFrames[projectile.type] = 6;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 58;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}
		
		public override bool MinionContactDamage()
		{
			return false;
		}
		int Timer;
		public override void AI()
		{
			Timer++;
			Player player = Main.player[projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.GoldenAutumnSpirit>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.GoldenAutumnSpirit>()))
			{
				projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			//special
			idlePosition.Y -= 100;

			float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 300f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					targetCenter.Y -= 300;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							targetCenter.Y -= 300;
							foundTarget = true;
						}
					}
				}
			}
			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 12f;
			float inertia = 30f;
			if (foundTarget)
			{
				if (distanceFromTarget > 40f) {
					Vector2 direction = idlePosition - projectile.Center; //targetCenter --> idlePosition
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					//speed = 12f;
					//inertia = 60f;
				}
				else {
					//speed = 4f;
					//inertia = 80f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
            #endregion

            #region Projectile
			Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 10;
			if (Timer % 60 == 0 && foundTarget)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, Main.rand.Next(7, 10), mod.ProjectileType("RedLeaf"), projectile.damage, projectile.knockBack, Main.myPlayer);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, Main.rand.Next(7, 10), mod.ProjectileType("OrangeLeaf"), projectile.damage, projectile.knockBack, Main.myPlayer);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, Main.rand.Next(7, 10), mod.ProjectileType("YellowLeaf"), projectile.damage, projectile.knockBack, Main.myPlayer);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, Main.rand.Next(7, 10), mod.ProjectileType("GreenLeaf"), projectile.damage, projectile.knockBack, Main.myPlayer);
			}
			
			#endregion

            #region Animation and visuals
            projectile.rotation = projectile.velocity.X * 0.05f;

			int frameSpeed = 5;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed) {
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type]) {
					projectile.frame = 0;
				}
			}
			for (int i = 0; i < 10; i++)
			{
				int dustType = 170;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Lighting.AddLight(projectile.Center, Color.YellowGreen.ToVector3() * 0.78f);
			#endregion
		}
	}
}