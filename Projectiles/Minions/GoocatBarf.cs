using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.Projectiles.Minions
{
	public class GoocatBarf : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 60;
		}
		int Timer;
		public override void AI() {
			Timer++;
			Projectile.velocity.Y *= 1.1f;
			Projectile.tileCollide = Timer > 6;
			Projectile.frame = (int)Projectile.ai[0];
			//Projectile.position.X = Main.projectile[(int)Projectile.ai[1]].Center.X - 16;
			//Projectile.position.Y = Main.projectile[(int)Projectile.ai[1]].Center.Y + (8*Timer);
			//if (Projectile.position.Y < Projectile.oldPos[0].Y) Projectile.position.Y = Projectile.oldPos[0].Y;
		}
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/GoocatBarf_" + Projectile.frame); //TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Minions/GoocatBarf_" + Projectile.frame);

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
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
            for (int i = 0; i < 5; i++) {
				int dustID = ModContent.DustType<Dusts.ElemDustGreen>();
				if (Projectile.frame == 1) dustID = ModContent.DustType<Dusts.ElemDustOrange>();
				if (Projectile.frame == 2) dustID = DustID.GoldCoin;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID);
				Dust dust = Main.dust[dustIndex];
				dust.velocity = Projectile.velocity;
				dust.velocity.Normalize();
				dust.velocity.Y *= -3f;
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-150, 151) * 0.01f;
				dust.scale *= 1.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
    }   
}