using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.OtherJavelances
{
	public class BleedingOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bleeding Javelance Blood");
        }
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 4;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
	}   
}