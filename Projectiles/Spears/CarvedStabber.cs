using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class CarvedStabber : SpearProj
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Carved Stabber");
		}
        public override void SpearDefaultsSafe()
        {
			Projectile.width = 40;
			Projectile.height = 40;
		}

		public CarvedStabber() : base(-18f, 32, 17.8f, 45f, 5, 35, 55f, 0f, 1.7f, false, false, false) { }
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}
	}
}