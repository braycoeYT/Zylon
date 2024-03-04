using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Materials
{
	public class OtherworldlyFang : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1, 50);
			Item.rare = ItemRarityID.Orange;
		}
	}
}