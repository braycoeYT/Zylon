using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Shadow
{
	public class Bloodbeat : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodbeat");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(467);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 467;
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