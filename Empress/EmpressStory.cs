using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class EmpressStory: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empress Story");
			Tooltip.SetDefault("It turns out slimes can have a social structure similar to ants.\nEmpress slimes have several reproduction systems allowing for them to give birth to slime larva at an absurd rate.");
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