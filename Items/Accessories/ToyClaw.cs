using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class ToyClaw : ModItem
	{
		public override void SetDefaults() {
			Item.width = 60;
			Item.height = 60;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2);
			Item.rare = ItemRarityID.White;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.whipRangeMultiplier += 0.2f;
		}
	}
}