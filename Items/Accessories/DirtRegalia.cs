using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class DirtRegalia : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'It's a royal mudallion'\nAllows minions to fire dirt balls if enemies are nearby");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Gray;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.dirtRegalia = true;
		}
	}
}