using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Dirtball
{
	public class StoryDirtball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirtball Story");
			Tooltip.SetDefault("An old prototype of the ancient desert discus.\nCrashed into mud when the final version came with a flash of light.");
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