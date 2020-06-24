using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class RadiationBlazeLarge : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiation Blaze");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(326);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.damage = 90;
			projectile.width = 28;
			projectile.height = 32;
			aiType = 326;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Poisoned, 300, false);
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Venom, 300, false);
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.CursedInferno, 300, false);
			target.AddBuff(BuffID.Stinky, 450, false);
		}
	}   
}