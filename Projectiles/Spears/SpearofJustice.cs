using Terraria;
using Terraria.ID;

namespace Zylon.Projectiles.Spears
{
	public class SpearofJustice : SpearProj
	{
        public override void SpearDefaultsSafe() {
            Projectile.width = 120;
            Projectile.height = 120;
        }
        public SpearofJustice() : base(-23f, 16, 5f, 110f, 2, 20, 115f, 0f, 1.5f, false, false, false) { }
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit);
				dust.noGravity = true;
				dust.scale = 0.8f;
			}
		}
	}
}