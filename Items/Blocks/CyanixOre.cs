using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blocks
{
	public class CyanixOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A basic Zylonian material that somehow made it to Terraria'");
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
			item.createTile = TileType<Tiles.CyanixOre>();
			item.width = 12;
			item.height = 12;
			item.value = 210;
			item.rare = 2;
		}
	}
}