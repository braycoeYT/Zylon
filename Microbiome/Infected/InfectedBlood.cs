using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome.Infected
{
	public class InfectedBlood : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Don't touch, unless you want to die a painfully slow death...");
		}

		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 40;
			item.maxStack = 999;
			item.value = 4500;
			item.rare = ItemRarityID.Orange;
		}
	}
}