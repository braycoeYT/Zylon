using Terraria;
using Terraria.ModLoader;

namespace Zylon.Backgrounds
{
	public class MicrobiomeSurfaceBgStyle : ModSurfaceBgStyle
	{
		public override bool ChooseBgStyle() {
			return !Main.gameMenu && Main.LocalPlayer.GetModPlayer<ZylonPlayer>().ZoneMicrobiome;
		}
		public override void ModifyFarFades(float[] fades, float transitionSpeed) {
			for (int i = 0; i < fades.Length; i++) {
				if (i == Slot) {
					fades[i] += transitionSpeed;
					if (fades[i] > 1f) {
						fades[i] = 1f;
					}
				}
				else {
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f) {
						fades[i] = 0f;
					}
				}
			}
		}
		public override int ChooseFarTexture() {
			return mod.GetBackgroundSlot("Backgrounds/MicrobiomeSurfaceFar");
		}
		private static int SurfaceFrameCounter;
		private static int SurfaceFrame;
		public override int ChooseMiddleTexture() {
			return mod.GetBackgroundSlot("Backgrounds/MicrobiomeSurfaceMid0");
		}
		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) {
			return mod.GetBackgroundSlot("Backgrounds/MicrobiomeSurfaceClose");
		}
	}
}