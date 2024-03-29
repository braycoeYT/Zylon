using Terraria;
using Terraria.ModLoader;

namespace Zylon.Buffs.Accessories
{
	public class LeafBracer : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Leaf Bracer");
			// Description.SetDefault("You are granted protection through the power of nature");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.immune = true;
		}
	}
}