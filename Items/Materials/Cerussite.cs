using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Materials
{
	public class Cerussite : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.maxStack = 9999;
			Item.width = 26;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.White;
		}
	}
}