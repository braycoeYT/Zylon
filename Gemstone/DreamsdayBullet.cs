using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Gemstone
{
	public class DreamsdayBullet : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreamsday Bullet");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;  
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.width = 8;
			projectile.height = 8;  
			projectile.friendly = true;
			projectile.penetrate = 12;
			projectile.ranged = true;
			projectile.damage = 28;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.light = 0.75f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet; 
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Frostburn, 350, false);
            if (Main.rand.Next(9) == 0)
		    target.AddBuff(BuffID.Venom, 350, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(9) == 0)
				target.AddBuff(BuffID.Frostburn, 350, false);
			if (Main.rand.Next(9) == 0)
				target.AddBuff(BuffID.Venom, 350, false);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}   
}