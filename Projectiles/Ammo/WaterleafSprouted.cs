using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class WaterleafSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Waterleaf");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 3;
			Projectile.rotation = 0;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 60 == 0)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2 (Main.rand.NextFloat(-5, 5), -8), ModContent.ProjectileType<WaterStreamRanged>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
        }
    }   
}