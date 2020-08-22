using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace Zylon.Projectiles.Gemstone
{
	public class GemstoneOrbLarge : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Large Gemstone Orb");
        }
		public override void SetDefaults()
		{
			projectile.width = 80;
			projectile.height = 80;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 30;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0f;
			aiType = ProjectileID.Bullet;
			projectile.melee = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.justHit = false;
		}
		public override void AI()
		{
			projectile.rotation += 0.05f;
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy((Math.PI / 180) * 15f, default), mod.ProjectileType("GemstoneOrbMedium"), projectile.damage, projectile.knockBack, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy((Math.PI / 180) * -15f, default), mod.ProjectileType("GemstoneOrbMedium"), projectile.damage, projectile.knockBack, Main.myPlayer);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 58);
				dust.noGravity = true;
				dust.scale = 2f;
			}
		}
	}   
}