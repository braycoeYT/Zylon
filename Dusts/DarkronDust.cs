using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class DarkronDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.scale = 1.5f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.rotation = Main.rand.NextFloat(6.28f);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}