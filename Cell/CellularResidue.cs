using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Cell
{
	public class CellularResidue : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cellular Residue");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
		}
	}   
}