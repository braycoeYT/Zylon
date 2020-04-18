using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Contagional
{
	public class OddFungus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Odd Fungus");
        }
		
		public override void SetDefaults()
		{
			projectile.width = 33;
			projectile.height = 33;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 15;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		    target.AddBuff(1 + Main.rand.Next(205), 60, false);
		}
	}   
}