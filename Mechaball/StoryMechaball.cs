using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mechaball
{
	public class StoryMechaball: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mechaball Story");
			Tooltip.SetDefault("It was abducted the Martians and they gave it all of their knowledge.\nIt tried to recreate everything it remembered but wanted to see something for real one last time:\nTerraria, and it hoped to destroy you.");
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