using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class DiskiteDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			//dust.color = new Color(22, 104, 108);
			dust.scale = 1.8f;
			dust.noGravity = false;
			dust.velocity /= 2f;
			dust.alpha = 100;
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			//Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.05f, 0.15f, 0.15f);
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}