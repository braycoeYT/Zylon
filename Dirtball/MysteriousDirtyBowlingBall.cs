using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Dirtball
{
	public class MysteriousDirtyBowlingBall : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Suspicious Dirty Bowling Ball");
			Tooltip.SetDefault("A dirty trick.\nDoes not roll well at all and can be used to ruin bowling careers.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 1;
			item.rare = -1;
		}
	}
}