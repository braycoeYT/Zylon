using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	[AutoloadEquip(EquipType.Body)]
	public class EarthmightBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Wearing this makes your mind dirty\nIncreases armor penetration by 2");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.rare = -1;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.armorPenetration += 2;
		}
	}
}