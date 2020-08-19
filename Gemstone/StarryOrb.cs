using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Net.NetworkInformation;

namespace Zylon.Projectiles.Gemstone
{
	public class StarryOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StarryOrb");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 30;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 1f;
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void AI()
		{
			projectile.rotation += 0.05f;
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 600, 0, -10, ProjectileID.StarWrath, projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 600, 0, 10, ProjectileID.StarWrath, projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X + 600, projectile.Center.Y, -10, 0, ProjectileID.StarWrath, projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X - 600, projectile.Center.Y, 10, 0, ProjectileID.StarWrath, projectile.damage, 6, Main.myPlayer);
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 243);
				dust.noGravity = true;
				dust.scale = 3f;
		}
	}   
}