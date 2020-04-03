using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class BrokenDiscus : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Obviously something very powerful built this'");
		}

		public override void SetDefaults() 
		{
			item.value = 250;
			item.rare = 1;
			item.maxStack = 99;
		}
	}
}