using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Shadow
{
	public class Bloodpick : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodpick");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(55);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 55;
		}
	}   
}