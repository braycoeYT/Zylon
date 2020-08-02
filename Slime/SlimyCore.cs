using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Slime
{
	public class SlimyCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slimy Core");
			Tooltip.SetDefault("Part of a slime nucleus");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 9999;
			item.value = 3500;
			item.rare = 0;
		}
	}
}