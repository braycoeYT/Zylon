using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Yoyos
{
	public class DirtBlockYoyo : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirt Block");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 450;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		int rand1 = Main.rand.Next(0, 360);
		int rand2 = Main.rand.Next(8, 17);
		float flash = 0f;
		float offset;
		float visibility;
        public override void AI() { //Projectile.velocity = new Vector2(Projectile.ai[1]/3f, -8);
			Projectile.ai[1]--;
			if (Projectile.ai[1] == 0) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(offset/3f, -8f), ModContent.ProjectileType<DirtBlockYoyo2>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
				Projectile.active = false;
			}
			else if (Projectile.ai[1] < 50) flash -= 0.1f;
			else if (Projectile.ai[1] < 60) flash += 0.1f;

			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation += 0.05f;
			Projectile.Center = main.Center - new Vector2(0, rand2).RotatedBy(MathHelper.ToRadians(rand1));
			if (Projectile.timeLeft > 15) Projectile.alpha -= 10;
			else Projectile.alpha += 30;
			if (main.active == false) Projectile.active = false;

			offset = Projectile.Center.X - main.Center.X;

			visibility += 0.1f;
			if (visibility > 1f) visibility = 1f;
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Yoyos/DirtBlockYoyo_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor*((255f-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*flash, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}