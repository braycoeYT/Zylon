using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class ContagionalInfo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Contagional Class Info");
			Tooltip.SetDefault("Information about Zylon's new class, Contagional.\nContagional attacks are unique because of their slightly lower damage but they inflict debuffs for more damage.\nA ~~~ symbol represents the debuff and its chances and length.\nContagional Regen Rate (Default: 2.5 Seconds) is how fast you regen contagion points but Contagional Regen Amount is how much you regen (Default: 6).\nThere is no visible Contagional Resource Bar but a ringing sound will play on 0 Contagion Points.\nAlso, a shorter version will play with less than 100 Contagion Points.\nThis class offers a unique challenge.\nI am trying to keep this class as balanced as possible.\nCurrently unfinished.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 0;
			item.rare = 1;
		}
	}
}