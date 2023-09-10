using System;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Zylon.Tiles.Ores;

namespace Zylon.WorldGeneration
{
	public class ZylonZincPass : GenPass
	{
		public ZylonZincPass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Growing Zinc spikes";
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					if (Framing.GetTileSafely(i, j).TileType == 367)
					{
						int badTiles = 0;
						for (int CheckUp = 0; CheckUp < 12; CheckUp++)
						{
							Tile tempTile = Framing.GetTileSafely(i, j - CheckUp + 2);
							if (tempTile.TileType != 367 && tempTile.WallType != 178)
							{
								badTiles++;
							}
							if (CheckUp > 6 && tempTile.HasTile)
							{
								badTiles++;
							}
						}
						for (int CheckDown = 0; CheckDown < 6; CheckDown++)
						{
							if (!Framing.GetTileSafely(i, j + CheckDown).HasTile)
							{
								badTiles++;
							}
						}
						if (badTiles <= 2 && WorldGen.genRand.NextBool(200))
						{
							WorldGenHelpers.ForcedTileCreation(i, j, (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(6, 12), ModContent.TileType<ZincOre>(), true, WorldGen.genRand.NextFloat(-1f, 1f), WorldGen.genRand.NextFloat(-2.5f, -2f));
						}
					}
				}
			}
		}
	}
}
