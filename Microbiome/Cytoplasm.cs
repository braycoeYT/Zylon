using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome
{
	public class Cytoplasm : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cytoplasm");
			Tooltip.SetDefault("Extremely enduring cell juice, in your hands...");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 750;
			item.rare = ItemRarityID.White;
		}
	}
}