using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Gigaslime
{
	public class AcornTreeGrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tree");
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 130;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 180;
			if (Main.expertMode)
				Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 9999;
			Projectile.rotation = 0;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if ((Timer % 90 == 0 && !Main.expertMode) || (Main.expertMode && Timer % 75 == 0))
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Microsoft.Xna.Framework.Vector2(Main.rand.NextFloat(-4, 4), -11), ModContent.ProjectileType<AcornTreeShoot>(), Projectile.damage, 0f, Main.myPlayer);
        }
    }   
}