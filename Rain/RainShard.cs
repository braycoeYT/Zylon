using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Rain
{
	public class RainShard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Rainy Shard");
			Tooltip.SetDefault("A basic shard of the ones that require mass hydration on land");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 101;
			item.rare = 0;
		}
	}
}