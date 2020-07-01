using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Linq;
using Ionic.Zip;

namespace Zylon.Projectiles.Mineral
{
	public class TargetMegaLaser : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Target Laser");
        }
		public override void SetDefaults()
		{
			projectile.width = 80;
			projectile.height = 80;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void AI()
		{
			projectile.rotation += 0.02f;
		}
	}   
}