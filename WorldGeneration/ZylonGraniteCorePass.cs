using System;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Zylon.Tiles;

namespace Zylon.WorldGeneration
{
	public class ZylonGraniteCorePass : GenPass
	{
		public ZylonGraniteCorePass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Increasing the granite energy";
			int coreAmount = 0;
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Framing.GetTileSafely(i, j);
					if (tile.WallType == 180 && !tile.HasTile && SquareEmpty(i, j, 4))
					{
						int cardinalDistanceAmount = 58;
						int GraniteIssue = 0;
						for (int horizontalCheck = i - cardinalDistanceAmount; horizontalCheck < i + cardinalDistanceAmount; horizontalCheck++)
						{
							Tile checkTile = Framing.GetTileSafely(horizontalCheck, j);
							if (horizontalCheck >= i)
							{
								if (checkTile.WallType != 180 && checkTile.TileType != 368)
								{
									GraniteIssue++;
								}
							}
							else if (checkTile.WallType != 180 || tile.HasTile)
							{
								GraniteIssue++;
							}
						}
						for (int verticalCheck = j - cardinalDistanceAmount; verticalCheck < j + cardinalDistanceAmount; verticalCheck++)
						{
							Tile checkTile2 = Framing.GetTileSafely(i, verticalCheck);
							if (verticalCheck >= j)
							{
								if (checkTile2.WallType != 180 && checkTile2.TileType != 368)
								{
									GraniteIssue++;
								}
							}
							else if (checkTile2.WallType != 180 || tile.HasTile)
							{
								GraniteIssue++;
							}
						}
						if (coreAmount > 0)
						{
							if ((float)GraniteIssue < (float)cardinalDistanceAmount / 2.5f && WorldGen.genRand.NextBool(50 * coreAmount) && NoNearbyCores(i, j, 100))
							{
								CreateCore(i, j);
								coreAmount++;
							}
						}
						else if (GraniteIssue < cardinalDistanceAmount / 2)
						{
							CreateCore(i, j);
							coreAmount++;
						}
					}
				}
			}
		}

		private bool SquareEmpty(int i, int j, int size)
		{
			for (int horizontalCount = i - size; horizontalCount < i + size; horizontalCount++)
			{
				for (int verticalCount = j - size; verticalCount < j + size; verticalCount++)
				{
					if (Framing.GetTileSafely(horizontalCount, verticalCount).HasTile)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool NoNearbyCores(int i, int j, int distance)
		{
			for (int horizontalCount = i - distance; horizontalCount < i + distance; horizontalCount++)
			{
				for (int verticalCount = j - distance; verticalCount < j + distance; verticalCount++)
				{
					if ((int)(Framing.GetTileSafely(horizontalCount, verticalCount).TileType) == ModContent.TileType<Tiles.Granite.EnergizedStone>())
					{
						return false;
					}
				}
			}
			return true;
		}

		private void CreateCore(int i, int j)
		{
			WorldGen.PlaceTile(i, j, ModContent.TileType<Tiles.Granite.EnergizedStone>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i, j + 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j - 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j - 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j + 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j + 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i, j + 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j + 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j + 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i, j - 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j - 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j - 2, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 2, j, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 2, j - 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 2, j + 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 2, j, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 2, j - 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i - 2, j + 1, ModContent.TileType<Tiles.Granite.EnergyGranite>(), false, false, -1, 0);
			WorldGen.PlaceTile(i + 2, j + 2, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 2, j + 2, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 2, j - 2, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 2, j - 2, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 3, j, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 3, j + 1, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 3, j - 1, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 3, j, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 3, j + 1, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 3, j - 1, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i, j + 3, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j + 3, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j + 3, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i, j - 3, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i + 1, j - 3, 369, false, false, -1, 0);
			WorldGen.PlaceTile(i - 1, j - 3, 369, false, false, -1, 0);
		}
	}
}
