using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class PlanteraTooth : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Sharp!");
		}

		public override void SetDefaults() 
		{
			item.maxStack = 9999;
			item.value = 500;
			item.rare = ItemRarityID.LightPurple;
		}
	}
}