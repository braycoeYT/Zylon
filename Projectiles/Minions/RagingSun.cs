using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class RagingSun : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
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
		bool foundTarget;
		int Timer = Main.rand.Next(0, 60);
		int animTimer;
		Vector2 targetCenter;
		NPC projTarget;
		public override void AI() {
			Timer++;
			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.RagingSun>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.RagingSun>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;
			//special
			idlePosition.Y -= 16;

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
			float distanceFromTarget = 900f;
			targetCenter = Projectile.position;
			foundTarget = false;

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
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							projTarget = npc;
						}
					}
				}
			}
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 8f;
			float inertia = 20f;
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
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
            #endregion

            #region Projectile
			Vector2 projDir = new Vector2(0, -6).RotatedByRandom(MathHelper.ToRadians(60));
			if (Timer % 30 == 0 && foundTarget) {
				if (projTarget != null && projTarget.active) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ProjectileType<RagingSunProj>(), Projectile.damage, Projectile.knockBack, Projectile.owner, projTarget.whoAmI);
			}
			#endregion

			#region Animation and visuals

			animTimer++;
			float rotateSpeed = 0f;
			if (animTimer % 60 < 13) switch (animTimer % 60) {
				case 0: case 12:
					rotateSpeed = MathHelper.ToRadians(1f);
					break;
				case 1: case 11:
					rotateSpeed = MathHelper.ToRadians(2f);
					break;
				case 2: case 10:
					rotateSpeed = MathHelper.ToRadians(3f);
					break;
				case 3: case 9:
					rotateSpeed = MathHelper.ToRadians(4f);
					break;
				default:
					rotateSpeed = MathHelper.ToRadians(5f);
					break;
			}
			Projectile.rotation += rotateSpeed;

			if (animTimer % 240 == 239) Projectile.rotation = 0; //Fun fact: This is the exact same error as the one in the Wii port of SM64 that makes Bowser in the Fire Sea 0xA. The decimals are rounded further than expected, which eventually leads to uneven displacement over long periods of time.

			Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.6f);
			#endregion
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D eyeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/RagingSun_Eye");
			
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

			Vector2 eyeOrigin = new Vector2(eyeTexture.Width * 0.5f, eyeTexture.Height * 0.5f);

			Vector2 eyeDrawPos = drawPos; //Projectile.Center + new Vector2(0, 4).RotatedBy(Projectile.velocity.ToRotation()) - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			if (foundTarget && projTarget != null && projTarget.active) {
				eyeDrawPos = Projectile.Center + Projectile.Center.DirectionTo(targetCenter)*4f - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			}

            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(eyeTexture, eyeDrawPos, null, color, 0f, eyeOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
	}
}