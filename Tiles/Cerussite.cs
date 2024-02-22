using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Tiles
{
	public class Cerussite : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 280;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 300;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			TileID.Sets.ChecksForMerge[Type] = true;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(200, 200, 200), name);
			DustType = DustType<Dusts.CerussiteDust>();
			HitSound = SoundID.Tink;
			MineResist = 1f;
			MinPick = 0;
		}
	}
	/*public class CerussiteOreSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				tasks.Insert(ShiniesIndex + 1, new CerussiteOrePass("Sprinkling in Zylonian Ores", 237.4298f));
			}
		}
	}

	public class CerussiteOrePass : GenPass
	{
		public CerussiteOrePass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = "Sprinkling in Zylonian Ores";

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.000065); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)((Main.maxTilesY-200+Main.rockLayer)*0.45f), Main.maxTilesY-200);
				Tile tile = Framing.GetTileSafely(x, y);
				if (tile.TileType == TileID.Stone)
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 12), WorldGen.genRand.Next(9, 12), ModContent.TileType<CerussiteOre>());
			}
		}
	}*/
}