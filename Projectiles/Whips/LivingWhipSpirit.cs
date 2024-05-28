using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Whips
{
	public class LivingWhipSpirit : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 2;
			Projectile.alpha = 255;
		}
		float rand = Main.rand.NextFloat(MathHelper.TwoPi);
		public override void AI() {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			Projectile.Center = player.Center; //Positioning, not too important.

			//Rotates the stuff.
			Projectile.rotation += 0.03f;
			rand += (16f-p.livingWhipNum)/200f;

			//Manage the variables
			p.livingWhipTimer--;
			if (p.livingWhipTimer <= 0) {
				p.livingWhipNum--;
				p.livingWhipTimer = 120;
			}
			if (p.livingWhipNum > 0) Projectile.timeLeft = 2;
		}
		public override bool PreDraw(ref Color lightColor) {
			Player player = Main.player[Projectile.owner];
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            //Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Wands/AdamantiteWandProj_Trail");
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = player.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White; //Projectile.GetAlpha(lightColor);
			
			//j = how many projectiles to spawn, k = trail for one projectile
            if (p.livingWhipNum > 0) for (int j = 0; j < p.livingWhipNum; j++) for (int k = 0; k < 15; k++) {
                Vector2 drawPosEffect = player.Center - new Vector2(0, 100).RotatedBy(MathHelper.ToRadians(-k+(j*(360/p.livingWhipNum)))+rand) - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) - new Vector2(Projectile.width/2, Projectile.height/2);
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, Color.White*((255f-k*17f)/255f), Projectile.oldRot[k], drawOrigin, Projectile.scale-(0.06f*k), SpriteEffects.None, 0);
            }
            //Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}
}