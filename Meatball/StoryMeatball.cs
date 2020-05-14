using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Meatball
{
	public class StoryMeatball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meatball Story");
			Tooltip.SetDefault("The dirtball found lots of meat lying around.\nSkeletron's corpse too.\nCan you guess what happened?");
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