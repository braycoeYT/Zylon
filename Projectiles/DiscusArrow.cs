using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class DiscusArrow : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discus Arrow");
        }
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.damage = 10;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.light = 0.5f;
			aiType = 1;
		}
	}   
}