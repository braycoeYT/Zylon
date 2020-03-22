using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DreamString : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It resembles some sort of septuple helix and can grant dreams'");
		}

		public override void SetDefaults() 
		{
			item.maxStack = 999;
			item.value = 2000;
		}
	}
}