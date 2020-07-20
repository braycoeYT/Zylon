using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ToolsofContagion
{
	public class InfectedOnyx : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A treasure of the microbiome");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 7500;
			item.rare = 11;
		}
	}
}