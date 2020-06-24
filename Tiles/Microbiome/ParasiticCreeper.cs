using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Microbiome
{
	public class ParasiticCreeper : ModTile
	{
		public override void SetDefaults()
		{
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			//TileObjectData.newTile.Width = 2;
			//TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileCut[Type] = false;
			Main.tileHammer[Type] = true;
			Main.tileFrameImportant[Type] = true;
			mineResist = 3f;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Parasitic Creeper");
			AddMapEntry(new Color(0, 63, 0), name);
			TileObjectData.addTile(Type);
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0f;
			g = 3f;
			b = 0f;
		}
		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 37;
			if (style == 0)
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ItemType<Items.Blocks.CyanixBar>());
			}
			return base.Drop(i, j);
		}
	}
}