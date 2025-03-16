using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class BinaryDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.scale = 1f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.frame = new Rectangle(0, Main.rand.Next(2) * 16, 16, 16);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation = 0f;
			dust.scale -= 0.02f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}