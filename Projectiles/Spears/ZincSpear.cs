using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class ZincSpear : SpearProj
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Zinc Spear");
		}
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 54;
            Projectile.height = 54;
        }
        public ZincSpear() : base(-23f, 20, 7.8f, 45f, 5, 20, 45f, 0f, 1.5f) { }


	}
}