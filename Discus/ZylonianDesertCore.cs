using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class ZylonianDesertCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Desert Core");
			Tooltip.SetDefault("'Old Era Zylonian Technology mixed with age and sand. Most Zylonians would disapprove.'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 200;
			item.rare = 1;
			item.useStyle = 4;
		}
	}
}