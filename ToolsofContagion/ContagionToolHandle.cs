using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ToolsofContagion
{
	public class ContagionToolHandle : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Contagion's Tool Handle");
			Tooltip.SetDefault("Contains an unknown past...");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 12500;
			item.rare = 11;
		}
	}
}