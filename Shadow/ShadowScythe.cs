using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Shadow
{
	public class ShadowScythe : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Scythe");
			Main.projFrames[projectile.type] = 8;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(44);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 44;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 8)
				{
					projectile.frame = 0;
				}
			}
		}
	}   
}