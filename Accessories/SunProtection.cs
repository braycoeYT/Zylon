using Terraria;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SunProtection : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sun's Protection");
			Tooltip.SetDefault("When you have low health, you have heavily increased life regen");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 250000;
			item.rare = 8;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.statLife < player.statLifeMax2 / 4)
			player.lifeRegen += 5;
		}
	}
}