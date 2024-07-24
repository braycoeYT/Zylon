using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles.Ores
{
	public class CarnalliteOre : ModTile
	{
        public override void SetStaticDefaults()
        {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 320;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1220;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(103, 217, 69), name); //110, 150, 98
			DustType = DustType<Dusts.CarnalliteOreDust>();
			HitSound = SoundID.Tink;
			MineResist = 1.5f;
			MinPick = 65;
		}
		public override bool CanExplode(int i, int j) {
			return false;
		}
	}
}