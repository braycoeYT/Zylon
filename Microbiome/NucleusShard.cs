using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome
{
	public class NucleusShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nucleus Shard");
			Tooltip.SetDefault("Eww, it's managing cells on my hands...");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 2500;
			item.rare = 0;
		}
	}
}