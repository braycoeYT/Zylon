using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class PinkGemblast : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Gemblast");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(467);
			if (Main.expertMode)
				projectile.damage = 170;
			else
				projectile.damage = 130;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 467;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(mod.BuffType("Crystalizing"), 30, false);
		}
		/*public override void AI()
		{
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
		}*/
	}   
}