using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class CandyCanePike : SpearProj
	{
        public override void SpearDefaultsSafe() {
			Projectile.width = 60;
			Projectile.height = 60;
		}
		public CandyCanePike() : base(-18f, 20, 20f, 40f, 3, 25, 55f, 0f, 1.5f, false, false, false) { }
	}
}