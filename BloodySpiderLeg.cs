using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class BloodySpiderLeg : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Spider Leg");
			Tooltip.SetDefault("Crunchy!");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 0;
		}
	}
}