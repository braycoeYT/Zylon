using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class TrueLoberaOrb : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
			Projectile.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		float rot;
		float tempFloat = 0f;
        public override void AI() {
			Projectile.alpha -= 17;
			rot += 2;
			Projectile main = Main.projectile[(int)Projectile.ai[0]];

			if (main.type == ModContent.ProjectileType<TrueLoberaBeam>()) tempFloat = 1f; //modifies rotation if the sword is being used so I don't have to make 2 projectiles

			Projectile.rotation -= 0.05f;
			Projectile.Center = main.Center - new Vector2(0, 16+(tempFloat*64)).RotatedBy(MathHelper.ToRadians((360/(4+(tempFloat*4)))+rot+(Projectile.ai[1]*(90-(45*tempFloat)))));
			if (main.active == false) Projectile.Kill();
        }
		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.LoberaDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/TrueLoberaOrb");

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
	}   
}