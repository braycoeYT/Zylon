using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Ores
{
	public class HaxoniteOre : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 350;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 500;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Haxonite Ore");
			AddMapEntry(new Color(211, 69, 0), name);
			DustType = DustType<Dusts.HaxoniteOreDust>();
			ItemDrop = ItemType<Items.Ores.HaxoniteOre>();
			HitSound = SoundID.Tink;
			MineResist = 2f;
			MinPick = 50;
		}
	}
}