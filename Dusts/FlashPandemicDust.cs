using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class FlashPandemicDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.noLight = true;
			dust.scale = 1.8f;
			dust.noGravity = false;
			dust.velocity /= 2f;
			dust.alpha = 0;
			dust.color = new Color(0, 230, 212);
		}
		public override bool Update(Dust dust) {
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0f, 0.2f, 0.18f);
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