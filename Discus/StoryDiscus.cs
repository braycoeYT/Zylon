using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class StoryDiscus : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ancient Desert Discus Story");
			Tooltip.SetDefault("It was sent to search for planets full of minerals as a part of the Mass Mineral Extraction.\nIt found Terraria but cut its signals once it learned of its beauty.\nIt swore to protect Terraria at all costs.");
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