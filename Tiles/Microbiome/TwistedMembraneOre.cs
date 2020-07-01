using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Microbiome
{
	public class TwistedMembraneOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 330;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1535;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Twisted Membrane Ore");
			AddMapEntry(new Color(0, 0, 180), name);
			dustType = 84;
			drop = ItemType<Items.Microbiome.TwistedMembraneOre>();
			soundType = 21;
			soundStyle = 1;
			mineResist = 1f;
			minPick = 55;
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0f;
			g = 0f;
			b = 0.9f;
		}
	}
}