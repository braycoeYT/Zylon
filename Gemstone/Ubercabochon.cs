using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Gemstone
{
	public class Ubercabochon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ubercabochon");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults()
		{
			projectile.width = 44;
			projectile.height = 44;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0f;
			projectile.penetrate = -1;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}
		
		public override bool MinionContactDamage()
		{
			return true;
		}
		int Timer = 600;
		int mode = 0;
		public override void AI()
		{
			Timer++;
			if (Timer % 1200 < 600)
			mode = 0;
			else
			mode = 1;
			Player player = Main.player[projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.Ubercabochon>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.Ubercabochon>()))
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
			float distanceFromTarget = 700f;
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
							foundTarget = true;
						}
					}
				}
			}
			projectile.friendly = foundTarget;
			#endregion
			if (Timer == 0 || Timer == 600)
			projectile.velocity = new Vector2(0, 0);
			#region Movement
			if (mode == 0)
			{
				float speed = 35f;
				float inertia = 55f;
				if (distanceToIdlePosition > 600f) {
					speed = 25f;
					inertia = 60f;
				}
				else {
					speed = 16f;
					inertia = 80f;
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
			if (mode == 1)
			{
				float speed = 35f;
				float inertia = 55f;

				if (foundTarget)
				{
					if (distanceFromTarget > 40f) {
						Vector2 direction = targetCenter - projectile.Center;
						direction.Normalize();
						direction *= speed;
						projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
					}
				}
				else {
					if (distanceToIdlePosition > 600f) {
						speed = 40f;
						inertia = 40f;
					}
					else {
						speed = 32f;
						inertia = 50f;
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
			}
			if (projectile.velocity == Vector2.Zero) {
				projectile.velocity.X = -0.15f;
				projectile.velocity.Y = -0.05f;
			}

            #endregion

            #region Projectile
			Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 10;
			if (mode == 0 && Timer % 30 == 0 && foundTarget)
			{
				Main.PlaySound(SoundID.Item10, projectile.position);
				Projectile.NewProjectile(projectile.Center, projDir, 20, projectile.damage, projectile.knockBack, Main.myPlayer);
			}

			#endregion

            #region Animation and visuals
			if (mode == 0)
			{
				projectile.spriteDirection = projectile.direction;
				projectile.rotation = projectile.velocity.X * 0.05f;
			}
            if (mode == 1)
			{
				projectile.rotation += (float)(Math.PI / 180) * 5f;
			}

			Lighting.AddLight(projectile.Center, Color.LightPink.ToVector3() * 0.3f);
			#endregion
		}
	}
}