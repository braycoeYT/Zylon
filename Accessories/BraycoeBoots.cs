using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class BraycoeBoots : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Braycoe's Boots");
			Tooltip.SetDefault("Secret bad item\nNot very worn at all!\nHyper speed is yours now\nGet an extraordinary headstart with the shield of cthulhu and similar items\n+30 max wing time");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 175849;
			item.rare = ItemRarityID.Purple;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxRunSpeed += 20f;
			player.wingTimeMax += 30;
		}
	}
}