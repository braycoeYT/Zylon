using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class CellMembrane : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Eww, it's melting in my hands...");
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
			item.createTile = TileType<Tiles.Microbiome.CellMembrane>();
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = 0;
		}
	}
}