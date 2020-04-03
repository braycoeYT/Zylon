using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blocks
{
	public class ObliviousMatter : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A part of a rotted and destroyed wasteland'");
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
			item.createTile = TileType<Tiles.ObliviousMatter>();
			item.width = 12;
			item.height = 12;
			item.value = 0;
			item.rare = 11;
		}
	}
}