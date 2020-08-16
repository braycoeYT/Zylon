using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherSeeds.PH.Crimson
{
	public class SproutedCrimtaneSeedshotGoodFall : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Crimtane Seedshot");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.penetrate = -1;
		}
		public override void Kill(int timeLeft)
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 125);
			dust.noGravity = true;
			dust.scale = 2f;
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 2, 0, 0, mod.ProjectileType("SproutedCrimtaneDeathweedGood"), 15, 0, Main.myPlayer);
		}
		public override void PostAI()
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 125);
			dust.noGravity = true;
			dust.scale = 1f;
		}
	}   
}