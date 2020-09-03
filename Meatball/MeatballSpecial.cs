using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Meatball
{
	public class MeatballSpecial : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meatball Special");
			Tooltip.SetDefault("Meatballs are replaced by big meatballs\nBig meatballs venom enemies instead of poison");
		}
		public override void SetDefaults() {
			item.width = 36;
			item.height = 60;
			item.accessory = true;
			item.value = 45000;
			item.rare = ItemRarityID.Orange;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.UpgradeMeatball = true;
		}
	}
}