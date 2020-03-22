using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class WoodenVirus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Virus");
        }
		
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 33;
			projectile.height = 33;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		    target.AddBuff(BuffID.Poisoned, 150, false);
		}
	}   
}