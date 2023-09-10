using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SpeckledStardust : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'It looks as if it fell from heaven (not to be confused with glitter, which rose from hell)'");
        }
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 28;
			Item.maxStack = 999;
			Item.value = 75;
			Item.rare = ItemRarityID.White;
		}
	}
}