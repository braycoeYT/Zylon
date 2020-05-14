using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class OblivionWood : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = ItemType<Items.Blocks.OblivionWood>();
			AddMapEntry(new Color(196, 25, 35));
			SetModTree(new Tiles.OblivionTree());
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.9f;
			g = 0.05f;
			b = 0.05f;
		}

		public override int SaplingGrowthType(ref int style) 
		{
			style = 0;
			return TileType<OblivionSapling>();
		}
	}
}