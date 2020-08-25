using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class ContagionAlloy : ModTile
	{
		public override void SetDefaults() {
			Main.tileShine[Type] = 600;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(22, 104, 108), Language.GetText("MapObject.MetalBar"));
		}
		public override bool Drop(int i, int j) {
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
			if (style == 0)
			{
				//Item.NewItem(i * 16, j * 16, 16, 16, ItemType<Items.ContagionTools.ContagionAlloy>());
			}
			return base.Drop(i, j);
		}
	}
}