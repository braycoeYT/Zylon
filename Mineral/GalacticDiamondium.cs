using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class GalacticDiamondium : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Galactic Diamondium");
			Tooltip.SetDefault("'A shard of the Zylonian Mineral Extractor. Very valuable.'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 70000;
			item.rare = 11;
		}
	}
}