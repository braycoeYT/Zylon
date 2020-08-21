using Terraria;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class FleshyCube : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max number of minions");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 150000;
			item.rare = 4;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.maxMinions += 1;
		}
	}
}