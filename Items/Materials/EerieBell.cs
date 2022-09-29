using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Materials
{
	public class EerieBell : ModItem
	{
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.Orange;
		}
	}
}