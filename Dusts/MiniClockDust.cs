using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class MiniClockDust : ModDust
	{
        public override void OnSpawn(Dust dust) { //Edit: I knew there was some way to fix the frames but I forgot how. Thanks! I also added the fourth clock.
			dust.noLight = true;
			//dust.color = new Color(22, 104, 108);
			dust.scale = 1.8f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			//dust.alpha = 100;
			dust.frame = new Rectangle(0, Main.rand.Next(4) * 18, 18, 18);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation = 0f;
			//Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.05f, 0.15f, 0.15f);
			dust.scale -= 0.02f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}