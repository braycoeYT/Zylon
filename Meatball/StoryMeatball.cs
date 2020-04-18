using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Meatball
{
	public class StoryMeatball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meatball Story");
			Tooltip.SetDefault("'After dirtball was defeated, the group of connected eyes found the corpses of Skeletron and other beasts.\nThey used skeletron for a new set of bones and the other beasts for, well, meat.\nMaybe you could find it roaming around with other abominations during the blood moon?'");
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