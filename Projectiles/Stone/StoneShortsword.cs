using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Stone
{
	public class StoneShortsword : ModProjectile
	{
		public const int FadeInDuration = 2; //7
		public const int FadeOutDuration = 2; //4

		public const int TotalDuration = 10; //16

		// The "width" of the blade
		public float CollisionWidth => 10f * Projectile.scale;

		public int Timer {
			get => (int)Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Shortsword");
		}

		public override void SetDefaults() {
			Projectile.Size = new Vector2(18);
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.scale = 1f;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ownerHitCheck = true;
			Projectile.extraUpdates = 1;
			Projectile.timeLeft = 360;
			Projectile.hide = true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			Timer += 1;
			if (Timer >= TotalDuration) {
				Projectile.Kill();
				return;
			}
			else {
				player.heldProj = Projectile.whoAmI;
			}
			Projectile.Opacity = Utils.GetLerpValue(0f, FadeInDuration, Timer, clamped: true) * Utils.GetLerpValue(TotalDuration, TotalDuration - FadeOutDuration, Timer, clamped: true);

			Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
			Projectile.Center = playerCenter + Projectile.velocity * (Timer - 1f);

			Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

			SetVisualOffsets();
		}

		private void SetVisualOffsets() {
			const int HalfSpriteWidth = 32 / 2;
			const int HalfSpriteHeight = 32 / 2;

			int HalfProjWidth = Projectile.width / 2;
			int HalfProjHeight = Projectile.height / 2;

			DrawOriginOffsetX = 0;
			DrawOffsetX = -(HalfSpriteWidth - HalfProjWidth);
			DrawOriginOffsetY = -(HalfSpriteHeight - HalfProjHeight);

			// Vanilla configuration for "hitbox towards the end"
			//if (Projectile.spriteDirection == 1) {
			//	DrawOriginOffsetX = -(HalfProjWidth - HalfSpriteWidth);
			//	DrawOffsetX = (int)-DrawOriginOffsetX * 2;
			//	DrawOriginOffsetY = 0;
			//}
			//else {
			//	DrawOriginOffsetX = (HalfProjWidth - HalfSpriteWidth);
			//	DrawOffsetX = 0;
			//	DrawOriginOffsetY = 0;
			//}
		}

		public override bool ShouldUpdatePosition() {
			return false;
		}

		public override void CutTiles() {
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Vector2 start = Projectile.Center;
			Vector2 end = start + Projectile.velocity.SafeNormalize(-Vector2.UnitY) * 10f;
			Utils.PlotTileLine(start, end, CollisionWidth, DelegateMethods.CutTiles);
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
			Vector2 start = Projectile.Center;
			Vector2 end = start + Projectile.velocity * 2f;
			float collisionPoint = 0f; // Don't need that variable, but required as parameter
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, CollisionWidth, ref collisionPoint);
		}
	}
}