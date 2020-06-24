using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Waters
{
	public class MicrobiomeWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("MicrobiomeSurfaceBgStyle");

		public override int ChooseWaterfallStyle()
			=> mod.GetWaterfallStyleSlot("MicrobiomeWaterfallStyle");

		public override int GetSplashDust()
			=> mod.DustType("MicrobiomeWaterSplash");

		public override int GetDropletGore()
			=> mod.GetGoreSlot("Gores/MicrobiomeDroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 0f;
			g = 0f;
			b = 0.2f;
		}

		public override Color BiomeHairColor()
			=> Color.Navy;
	}
}