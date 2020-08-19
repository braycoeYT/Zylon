using Terraria;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class FruitOfLife : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fruit of Life");
			Tooltip.SetDefault("Increases max life by 20\nYou gain life every time you take damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 65000;
			item.rare = 7;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 20;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.hurtHeal = true;
		}
	}
}