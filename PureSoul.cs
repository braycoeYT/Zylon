using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class PureSoul : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lark Mass");
			Tooltip.SetDefault("'Raincore's creation.'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 6700;
			item.rare = 10;
		}
	}
}