using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blocks
{
	public class EctojeweloOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A very rare and powerful ore");
		}
		
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.EctojeweloOre>();
			item.width = 12;
			item.height = 12;
			item.value = 10000;
			item.rare = 11;
		}
	}
}