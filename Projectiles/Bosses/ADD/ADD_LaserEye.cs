using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADD_LaserEye : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Desert Diskite");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = false;
			Projectile.aiStyle = -1;
		}
        public override void AI() {
            
        }
    }   
}