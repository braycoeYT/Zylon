using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Guns
{
	public class SilverFauxBlast : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Faux Blast");

			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 2;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 1200;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(2))
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.MoltenDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, Color.White, 1.3f);

            Projectile.ai[0]++;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            if (Projectile.ai[0] >= 25f)
            {
                Blast();
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 260);
            Projectile.damage = (int)(Projectile.damage*0.7f);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                target.AddBuff(BuffID.OnFire, 260);
            }
        }
        public void Blast()
        {
            for (int i = 0; i < 3; i++)
            {
                ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-7, 7))), ModContent.ProjectileType<MoltenBullet>(), (int)(Projectile.originalDamage / 3.1f), Projectile.knockBack, Projectile.owner, 0f, 0f);
            }

            Projectile.Kill();
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            for (int d = 0; d < 30; d++)
            {
                Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<Dusts.MoltenDust>(), Main.rand.NextFloat(-12, 12), Main.rand.NextFloat(-12, 12), 0, Color.White, 1.5f);
            }
            SoundEngine.PlaySound(SoundID.DD2_PhantomPhoenixShot, Projectile.position);
        }



        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glow = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Guns/SilverFauxBlast_glow");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.5f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k / 8f)) + Projectile.scale;
                Main.spriteBatch.Draw(glow, drawPosEffect, null, colorAfterEffect, Projectile.rotation, drawOrigin, AfterAffectScale, SpriteEffects.None, 0);
            }

            Main.spriteBatch.Draw(glow, drawPos, null, color * 0.7f, Projectile.rotation, drawOrigin, Projectile.scale * 1.2f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }   
}