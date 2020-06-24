using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Mineral
{
	public class TacticalNukeZME : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ZK-1");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 58;
			projectile.height = 120;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.tileCollide = false;
			projectile.light = 0.2f;
			if (Main.expertMode)
				projectile.damage = 109;
			else
				projectile.damage = 72;
		}
		int rand;
		public override void AI()
		{
			rand = Main.rand.Next(1, 4);
			if (rand == 1 && projectile.timeLeft % 5 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("RadiationBlazeSmall"), 30, 2, Main.myPlayer);
			}
			else if (rand == 2 && projectile.timeLeft % 5 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("RadiationBlazeMedium"), 40, 2, Main.myPlayer);
			}
			else if (projectile.timeLeft % 5 == 0)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("RadiationBlazeLarge"), 50, 2, Main.myPlayer);
			}
			projectile.rotation += 0.02f;
		}
	}   
}