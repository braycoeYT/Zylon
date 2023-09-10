using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class ZincSpear : SpearProj
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Zinc Spear");
		}
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 54;
            Projectile.height = 54;
        }
        public ZincSpear() : base(-23f, 24, 7.8f, 55f, 2, 30, 60f, 0f, 1.5f, false, false, false) { }

		public override void PostAI()
		{
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ZincDust>());
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}

	}
}