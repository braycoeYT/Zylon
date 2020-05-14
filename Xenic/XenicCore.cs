using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Xenic
{
	public class XenicCore : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A very compact and powerful core\nHolding this makes you feel like you are being watched...");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.maxStack = 999;
			item.value = 75000;
			item.rare = 12;
		}
	}
}