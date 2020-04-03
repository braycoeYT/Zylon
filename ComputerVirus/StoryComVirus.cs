using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.ComputerVirus
{
	public class StoryComVirus: ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus Story");
			Tooltip.SetDefault("'It started as some sort of paradox or glitch but seemed to like computers.\nWell, destroying computers.\nIt only serves a purpose for loss of information and creating chaos.\nKilling the computer virus is technically impossible because of its reality warping powers.\nOh well, it would make the world, no, the universe, a better place if it died.\nSadly viruses never run out of energy or get tired of doing the same thing.\nEvery day it creates and spreads trillions of minor copies of itself.\nMaybe an odd feeling disc could taunt it during the night?'");
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