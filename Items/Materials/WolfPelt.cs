using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class WolfPelt : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.LightRed;
		}
	}
}