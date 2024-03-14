using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class TabooEssence : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 12);
			Item.rare = ItemRarityID.LightRed;
		}
	}
}