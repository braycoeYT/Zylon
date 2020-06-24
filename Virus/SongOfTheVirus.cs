using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Virus
{
	public class SongOfTheVirus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Song of the Virus");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(575);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.width = 64;
			projectile.height = 64;
			aiType = 575;
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