using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class OverheatDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
		}
		public override bool Update(Dust dust) {
			dust.position += (dust.velocity / 1.75f);
			dust.alpha += 1;
			dust.scale -= 0.03f;
			dust.rotation += 0.05f;

			Lighting.AddLight(dust.position, (0.82745098039f * (dust.scale/1.5f)), (0.20784313725f * (dust.scale / 1.5f)), (0.52156862745f * (dust.scale / 1.5f)));


			if (dust.scale < 0.3f) {
				dust.active = false;
			}
			return false;
		}
	}
}