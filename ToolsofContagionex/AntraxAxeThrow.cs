using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.ToolsofContagionex
{
	public class AntraxAxeThrow : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hurling Axe");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(44);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 44;
		}
	}   
}