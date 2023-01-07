using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class ZombieRotDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.noLight = true;
			dust.scale = 1.8f;
			dust.noGravity = false;
			dust.velocity /= 2f;
			dust.alpha = 0;
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