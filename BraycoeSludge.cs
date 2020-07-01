using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class BraycoeSludge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ordinary Amoeba");
			Tooltip.SetDefault("Somehow visible without a microscope");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 946;
			item.rare = 2;
		}
	}
}