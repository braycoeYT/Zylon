using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class JadeDust2 : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.scale = 1.8f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.alpha = 100;
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.34f, 0.58f, 0.2f);
			dust.scale -= 0.05f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}