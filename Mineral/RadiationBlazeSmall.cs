using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class RadiationBlazeSmall : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiation Blaze");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(328);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.damage = 70;
			projectile.width = 12;
			projectile.height = 24;
			aiType = 328;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Poisoned, 100, false);
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Venom, 100, false);
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.CursedInferno, 100, false);
			target.AddBuff(BuffID.Stinky, 150, false);
		}
	}   
}