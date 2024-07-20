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
	public class DirtBlockVanity : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.minionSlots = 0f;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
			Projectile.frame = Main.rand.Next(0, 3);
		}
		public override bool? CanCutTiles() { //almost forgot this
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		public override void AI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			#region Active check
			/*if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.DirtBlockVanity>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.DirtBlockVanity>()))
			{
				Projectile.timeLeft = 2;
			}*/
			Projectile.timeLeft = 2;
			if (!p.dirtballExpertVanity) Projectile.Kill();
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center + new Vector2(0, 48).RotatedByRandom(2*Math.PI);

			//float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -player.direction;
			//idlePosition.X += minionPositionOffsetX;
			
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

			#region Movement

			float speed = 20f;
			float inertia = 60f;
			if (distanceToIdlePosition > 600f) {
				speed = 25f;
				inertia = 80f;
			}
			else {
				speed = 20f;
				inertia = 60f;
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
			#endregion

			#region Animation and visuals
			Projectile.rotation += 0.02f;
			#endregion
		}

		public override bool PreDraw(ref Color lightColor) {
			Texture2D projectileTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/DirtBlockExp");
			Texture2D trailTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/DirtBlockExp_trail");

			int frameHeight = projectileTexture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, projectileTexture.Width, frameHeight);
			Vector2 drawOrigin = sourceRectangle.Size() / 2f;
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);


			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color colorAfterEffect2 = Color.White * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.25f;
				Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
				Main.spriteBatch.Draw(trailTexture, drawPosEffect, sourceRectangle, colorAfterEffect2, Projectile.oldRot[k], drawOrigin, (Projectile.scale - k / (float)Projectile.oldPos.Length / 3) + 0.1f, SpriteEffects.None, 0);
				Main.spriteBatch.Draw(projectileTexture, drawPosEffect, sourceRectangle, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, SpriteEffects.None, 0);
			}

			Main.spriteBatch.Draw(trailTexture, drawPos, sourceRectangle, Projectile.GetAlpha(Color.White) * 0.5f, Projectile.rotation, drawOrigin, Projectile.scale + 0.1f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(projectileTexture, drawPos, sourceRectangle, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

			return false;
		}
	}
}