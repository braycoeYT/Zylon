using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class CyanixOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 505;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 975;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("CyanixOre");
			AddMapEntry(new Color(0, 255, 255), name);
			dustType = 84;
			drop = ItemType<Items.Blocks.CyanixOre>();
			soundType = 21;
			soundStyle = 1;
			mineResist = 2f;
			minPick = 55;
		}
	}
}