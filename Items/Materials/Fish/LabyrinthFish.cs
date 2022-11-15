using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials.Fish
{
	public class LabyrinthFish : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Its scales are beautifully complex'");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 15);
			Item.rare = ItemRarityID.Blue;
		}
	}
}