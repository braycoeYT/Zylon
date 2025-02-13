using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class StarParasiteDashDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
			dust.scale = 1f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			//dust.alpha = 100;
			dust.frame = new Rectangle(0, 0, 22, 22);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation = 0f;
			dust.velocity *= 0.95f;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.05f, 0.15f, 0.15f);
			dust.scale -= 0.02f;
			if (dust.scale < 0.02f) {
				dust.active = false;
			}
			return false;
		}
	}
}