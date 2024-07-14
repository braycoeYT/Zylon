using Terraria.ModLoader;

namespace Zylon
{
	public class ZylonKeybindSystem : ModSystem
	{
		public static ModKeybind DoublePluggedCordKeybind { get; private set; }

		public override void Load() {
			DoublePluggedCordKeybind = KeybindLoader.RegisterKeybind(Mod, "DoublePluggedCord", "Q");
		}
		public override void Unload() {
			DoublePluggedCordKeybind = null;
		}
	}
}