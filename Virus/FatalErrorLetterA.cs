using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Virus
{
	public class FatalErrorLetterA : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fatal Error");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void AI()
		{
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.X += 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.X -= 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.Y += 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.Y -= 1;
			if (Main.rand.NextFloat() < .01f)
			projectile.timeLeft += 60;
			if (Main.rand.NextFloat() < .02f)
			projectile.tileCollide = !projectile.tileCollide;
			if (Main.rand.NextFloat() < .02f)
			projectile.ignoreWater = !projectile.ignoreWater;
			if (Main.rand.NextFloat() < .02f)
			projectile.aiStyle = Main.rand.Next(0, 147);
		}
		public override void Kill(int timeLeft)
		{
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetter1"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetter3"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterA"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterB"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterHappy"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterZ"), projectile.damage, projectile.knockBack, Main.myPlayer);
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}