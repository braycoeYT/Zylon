using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class TrueLoberaBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
		}
		bool init;
        public override void AI() {
			if (!init && Main.myPlayer == Projectile.owner) {
				for (int i = 0; i < 8; i++)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<TrueLoberaOrb>(), (int)(Projectile.damage*0.5f), Projectile.knockBack/2, Projectile.owner, Projectile.whoAmI, i);
				init = true;
			}
			Projectile.rotation += 0.2f;
        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/TrueLoberaBeam");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, projectileTexture.Height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Projectile.GetAlpha(lightColor);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 9; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
    }   
}