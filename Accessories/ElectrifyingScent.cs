using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class ElectrifyingScent : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electrifying Scent");
			Tooltip.SetDefault("What does electricity even smell like?\nImmune to being electrified");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 20000;
			item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[144] = true;
		}
	}
}