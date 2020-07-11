using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DreamString : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("The code of the universe");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.maxStack = 999;
			item.value = 2000;
		}
	}
}