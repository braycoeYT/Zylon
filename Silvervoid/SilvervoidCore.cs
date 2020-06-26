using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Silvervoid
{
	public class SilvervoidCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silvervoid Core");
			Tooltip.SetDefault("A mysterious object that empowers evil");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 75000;
			item.rare = 10;
		}
	}
}