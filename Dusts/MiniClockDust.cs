using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class MiniClockDust : ModDust
	{
        public override void OnSpawn(Dust dust) { //Tome man I am sorry for breaking this dust. In case you want to know what I was trying to do, I wanted the full clock to show.
			dust.noLight = true;
			//dust.color = new Color(22, 104, 108);
			dust.scale = 1.8f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			//dust.alpha = 100;
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