using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SearedStone : ModItem
	{
		public override void SetDefaults() { //Add cool glow effect?
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.Green;
		}
	}
}