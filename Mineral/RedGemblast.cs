using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class RedGemblast : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Gemblast");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(467);
				projectile.damage = 55;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 467;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Bleeding, 180, false);
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