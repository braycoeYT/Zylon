using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class ElemDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.color = new Color(255, 220, 0);
			dust.scale = 1.8f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.alpha = 100;
		}
		int Timer;
		public override bool Update(Dust dust) {
			Timer++;
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			Vector3 yeah = new Vector3(0.1f, 0.8f, 0f);
			if (Timer % 120 < 60) yeah = new Vector3(0.5f, 0.1f, 0f);
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), yeah.X, yeah.Y, yeah.Z);
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}