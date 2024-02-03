using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class IcicleonaRod : SpearProj
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
        }
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 54;
            Projectile.height = 54;
        }
        public IcicleonaRod() : base(-23f, 24, 10.8f, 65f, 2, 30, 60f, 0f, 1.5f, false, false, false) { }
		public override void SpearInRadianSwing() {
			if (Duration == (RadianSwingFrames/2)) {
				for (int i = 0; i < 4; i++) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceGolem);
					dust.noGravity = true;
					dust.scale = 1.2f;
					dust.velocity = Projectile.velocity * 8f;
				}
				Vector2 speed = Projectile.velocity;
						speed.Normalize();
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center+(speed*50f), speed*9f, ModContent.ProjectileType<IcicleonaRodBreak>(), (int)(Projectile.damage*0.5f), Projectile.knockBack*0.33f, Projectile.owner);
				Projectile.frame = 1;
			}
        }
		public override void SpearInThrustSwing() {
			if (Duration == (ThrustFrames/2)) {
				for (int i = 0; i < 4; i++) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceGolem);
					dust.noGravity = true;
					dust.scale = 1.2f;
					dust.velocity = Projectile.velocity * 8f;
				}
				Vector2 speed = Projectile.velocity;
						speed.Normalize();
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center+(speed*50f), speed*9f, ModContent.ProjectileType<IcicleonaRodBreak>(), (int)(Projectile.damage*0.5f), Projectile.knockBack*0.33f, Projectile.owner);
				Projectile.frame = 1;
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceGolem);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}
}