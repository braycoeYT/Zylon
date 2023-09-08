using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Ores
{
	public class ZincOre : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 235;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 775;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Zinc Ore");
			AddMapEntry(new Color(108, 158, 181), name);
			DustType = DustType<Dusts.ZincDust>();
			ItemDrop = ItemType<Items.Ores.ZincOre>();
			HitSound = SoundID.Tink;
			MineResist = 1f;
			MinPick = 0;
		}
	}
}