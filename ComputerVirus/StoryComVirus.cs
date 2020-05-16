using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ComputerVirus
{
	public class StoryComVirus: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus Story");
			Tooltip.SetDefault("'It started as some sort of paradox or glitch but seemed to like computers.\nWell, destroying computers.\nIt created countless clones of itself that only had one objective: Cause as much information loss and destruction as possible.");
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