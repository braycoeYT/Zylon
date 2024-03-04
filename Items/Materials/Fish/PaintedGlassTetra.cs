using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials.Fish
{
	public class PaintedGlassTetra : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 34;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 17, 50);
			Item.rare = ItemRarityID.Blue;
		}
	}
}