using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Xenic
{
	public class XenicStory : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenic Acidpumper Story");
			Tooltip.SetDefault("A mysterious lab experiment.\nIt seems to have gained power after you destroyed the mineral extractor.");
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 0;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.expert = true;
		}
	}
}