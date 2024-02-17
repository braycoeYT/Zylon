using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SlimePendant : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.jumpSpeedBoost += 1.25f;
			player.maxFallSpeed += 3f;
		}
	}
}