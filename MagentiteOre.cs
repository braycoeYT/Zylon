using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class MagentiteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 75;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 345;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Magentite Ore");
			AddMapEntry(new Color(255, 0, 127), name);
			dustType = 100;
			drop = ItemType<Items.Magentite.MagentiteOre>();
			soundType = 21;
			soundStyle = 1;
			mineResist = 1f;
			minPick = 15;
		}
	}
}