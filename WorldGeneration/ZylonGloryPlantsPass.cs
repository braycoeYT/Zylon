using System;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Zylon.Tiles;

namespace Zylon.WorldGeneration
{
	public class ZylonGloryPlantsPass : GenPass
	{
		public ZylonGloryPlantsPass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Increasing glory";
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Framing.GetTileSafely(i, j);
					if ((int)(tile.TileType) == ModContent.TileType<Tiles.Marble.BloodLeaves>() && !Main.tile[i, j + 1].HasTile && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid)
					{
						int PlantType = WorldGen.genRand.Next(0, 2);
						if (PlantType != 0)
						{
							if (PlantType == 1)
							{
								WorldGen.PlaceTile(i, j + 1, ModContent.TileType<Tiles.Marble.GloryGrasses>(), false, false, -1, 0);
								Main.tile[i, j + 1].TileType = (ushort)ModContent.TileType<Tiles.Marble.GloryGrasses>();
							}
						}
						else
						{
							AttemptGloryVine(i, j, WorldGen.genRand.Next(1, 12));
						}
					}
					if ((tile.TileType == 367 || tile.TileType == 357) && !Main.tile[i, j - 1].HasTile && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && WorldGen.genRand.NextBool(12))
					{
						WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Tiles.Marble.GloryBlossom>(), false, false, -1, 0);
						Main.tile[i, j - 1].TileType = (ushort)ModContent.TileType<Tiles.Marble.GloryBlossom>();
					}
				}
			}
		}

		private void AttemptGloryVine(int i, int j, int length)
		{
			for (int placedVines = 0; placedVines < length; placedVines++)
			{
				Tile vineTile = Framing.GetTileSafely(i, j + placedVines);
				if (!vineTile.HasTile)
				{
					WorldGen.PlaceTile(i, j + placedVines, ModContent.TileType<Tiles.Marble.GloryVines>(), false, false, -1, 0);
					vineTile.TileType = (ushort)ModContent.TileType<Tiles.Marble.GloryVines>();
				}
			}
		}
	}
}
