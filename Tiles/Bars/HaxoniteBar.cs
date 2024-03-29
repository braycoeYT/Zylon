using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Bars
{
	public class HaxoniteBar : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileShine[Type] = 900;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(93, 138, 161), Language.GetText("MapObject.MetalBar"));
			DustType = DustType<Dusts.HaxoniteOreDust>();
		}
	}
}