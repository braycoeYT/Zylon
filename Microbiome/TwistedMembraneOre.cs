using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class TwistedMembraneOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Eww, it's twisting in my hands...");
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
			item.createTile = TileType<Tiles.Microbiome.TwistedMembraneOre>();
			item.width = 12;
			item.height = 12;
			item.value = 210;
			item.rare = 1;
		}
	}
}