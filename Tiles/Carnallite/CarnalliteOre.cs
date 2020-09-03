using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Carnallite
{
	public class CarnalliteOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 750;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 835;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Carnallite Ore");
			AddMapEntry(new Color(230, 73, 73), name);
			dustType = mod.DustType("CarnalliteDust");
			drop = ItemType<Items.Carnallite.CarnalliteOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 4f;
			minPick = 200;
		}
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
	}
}