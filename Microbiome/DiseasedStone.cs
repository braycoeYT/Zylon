using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	public class DiseasedStone : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Eww, it's oozing in my hands...");
		}
		
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Microbiome.DiseasedStone>();
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = ItemRarityID.White;
		}
	}
}