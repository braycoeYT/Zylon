using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class ObeliskDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
		}
		public override bool Update(Dust dust) {
			dust.position += (dust.velocity / 4f);
			dust.alpha += 1;
			dust.scale -= 0.03f;
			dust.rotation += 0.05f;

			if (dust.scale < 0.3f) {
				dust.active = false;
			}
			return false;
		}
	}
}