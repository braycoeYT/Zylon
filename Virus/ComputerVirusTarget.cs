using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Virus
{
	public class ComputerVirusTarget : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Computer Virus?");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 400;
			projectile.height = 170;
			projectile.aiStyle = 0;
			projectile.hostile = false;
			projectile.friendly = false;
			if (Main.expertMode)
				projectile.timeLeft = 45;
			else
				projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0f;
			projectile.damage = 0;
			projectile.alpha = 190;
		}
	}   
}