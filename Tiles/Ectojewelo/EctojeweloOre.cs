using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Ectojewelo
{
	public class EctojeweloOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 1001;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 835;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Ectojewelo Ore");
			AddMapEntry(new Color(0, 125, 125), name);
			dustType = 229;
			drop = ItemType<Items.Ectojewelo.EctojeweloOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 6f;
			minPick = 230;
		}
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
	}
}