using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherSeeds
{
	public class SproutedSeedFall : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Seed");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.penetrate = -1;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 10, 0, 0, mod.ProjectileType("SproutedSapling"), 15, 0, Main.myPlayer);
		}
	}   
}