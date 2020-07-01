using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class RadiationBlazeMedium : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiation Blaze");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(327);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.damage = 80;
			projectile.width = 24;
			projectile.height = 28;
			aiType = 327;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Poisoned, 200, false);
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Venom, 200, false);
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.CursedInferno, 200, false);
			target.AddBuff(BuffID.Stinky, 300, false);
		}
	}   
}