using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class GalacticDiamondium : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Galactic Diamondium");
			Tooltip.SetDefault("It appears to be a part of the mineral extractor,\nbut it seems that it has been tinkered with too much to return to its original state.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 70000;
			item.rare = 11;
		}
	}
}