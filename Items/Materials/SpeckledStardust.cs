using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SpeckledStardust : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = 75;
			Item.rare = ItemRarityID.White;
		}
	}
}