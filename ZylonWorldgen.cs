using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace Zylon
{
	public class ZylonOreSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				tasks.Insert(ShiniesIndex + 1, new ZylonOrePass("Zylon Ores", 237.4298f));
			}
		}
	}

	public class ZylonOrePass : GenPass
	{
		public ZylonOrePass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = "Sprinkling in Zylon Ores";

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 7E-05); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), ModContent.TileType<Tiles.Ores.ZincOre>());
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.HasTile && tile.TileType == TileID.SnowBlock) {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}
	}
}