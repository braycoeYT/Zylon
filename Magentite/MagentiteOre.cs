using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	public class MagentiteOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("It's a lot spikier than it looks");
		}
		
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileType<Tiles.MagentiteOre>();
			item.width = 12;
			item.height = 12;
			item.value = 95;
			item.rare = 2;
		}
	}
}