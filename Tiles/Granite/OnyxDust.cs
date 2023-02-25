using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Tiles.Granite
{
	public class OnyxDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 10, 10, 10);
			dust.rotation = Main.rand.NextFloat(6.28f);
		}

		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			return new Color?(Color.White * ((255f - (float)dust.alpha) / 255f));
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += 0.02f;
			dust.position += new Vector2(0f, -0.55f);
			dust.scale -= 0.005f;
			dust.alpha++;
			if (dust.scale < 0.05f || dust.alpha >= 255)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
