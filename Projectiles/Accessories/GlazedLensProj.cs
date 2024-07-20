using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.Projectiles.Accessories
{
	public class GlazedLensProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.alpha = 255;
		}
		Player main;
		int critBoost;
		float rSpeed;
		float totalRot;

		float rot;
		float rot2;
        public override void AI() {
			Projectile.netUpdate = true;
			main = Main.player[Projectile.owner];
			critBoost = (int)Projectile.ai[0];
			if (critBoost < 0) critBoost = 0;
			if (critBoost > 100) critBoost = 100;
			rSpeed = 2 + (5*critBoost/100);
			totalRot += rSpeed;
			Projectile.Center = main.Center - new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(totalRot));
			//Projectile.rotation = MathHelper.ToRadians(totalRot); //For old proj
			if (totalRot < 300) Projectile.alpha -= 10 + (15*critBoost/100);
			else Projectile.alpha += 30 + (30*critBoost/100);
			if (totalRot >= 300 && Projectile.alpha > 254) Projectile.active = false;

			rot += MathHelper.ToRadians(5f+(10f*critBoost/100));
			rot2 -= MathHelper.ToRadians(3f+(6f*critBoost/100));
			Lighting.AddLight(Projectile.Center, Color.CadetBlue.ToVector3() * 0.4f);
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/GlazedLensProj");
			Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Accessories/GlazedLensProj2");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int frameHeight2 = texture2.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Color color = Projectile.GetAlpha(lightColor);

			Main.EntitySpriteDraw(texture2, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture2.Width, frameHeight2)), color, rot2, new Vector2(texture2.Width / 2f, frameHeight2 / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), color, rot, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale*1.2f, effects, 0);
			return false;
		}
	}   
}