using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class FireblossomSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fireblossom");
        }
		public override void SetDefaults() {
			Projectile.width = 12;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 4;
			Projectile.rotation = 0;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 60 == 0)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2 (Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(-8, -4)), ModContent.ProjectileType<BallofFireRanged>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
        }
    }   
}