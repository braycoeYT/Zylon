using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome.Contagionite
{
	public class Contagionite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Born from radioactive waste, don't touch them with your bare hands");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 7;
		}
	}
}