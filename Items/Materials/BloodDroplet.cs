using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class BloodDroplet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 38;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1);
			Item.rare = ItemRarityID.Blue;
		}
	}
}