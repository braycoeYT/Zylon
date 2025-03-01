using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Food
{
	public class CocoaBeans : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 0, 40);
			Item.rare = ItemRarityID.Blue;
		}
	}
}