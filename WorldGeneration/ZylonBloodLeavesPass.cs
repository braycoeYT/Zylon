using System;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Zylon.Tiles;

namespace Zylon.WorldGeneration
{
	public class ZylonBloodLeavesPass : GenPass
	{
		public ZylonBloodLeavesPass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Making blood";
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Framing.GetTileSafely(i, j);
					if (tile.TileType == 367 && !Main.tile[i, j + 1].HasTile && Main.tile[i, j + 1].WallType == 178)
					{
						int badTiles = 0;
						for (int CheckUp = 0; CheckUp < 55; CheckUp++)
						{
							if ((int)(Framing.GetTileSafely(i, j - CheckUp + 2).TileType) == ModContent.TileType<Tiles.Marble.BloodLeaves>())
							{
								badTiles++;
							}
						}
						if (badTiles <= 0)
						{
							tile.TileType = (ushort)ModContent.TileType<Tiles.Marble.BloodLeaves>();
							tile.Slope = SlopeType.Solid;
							tile.IsHalfBlock = false;
							badTiles = 0;
							for (int CheckUpAgain = 0; CheckUpAgain < 7; CheckUpAgain++)
							{
								Tile tempTile = Framing.GetTileSafely(i, j - CheckUpAgain);
								if (!tempTile.HasTile || tempTile.TileType != 367)
								{
									badTiles++;
								}
							}
							int amountOfUpperLeaves = WorldGen.genRand.Next(3, 7);
							if (badTiles > 1)
							{
								amountOfUpperLeaves = WorldGen.genRand.Next(5, 8);
							}
							for (int grownLeaves = 0; grownLeaves < amountOfUpperLeaves; grownLeaves++)
							{
								Tile leafTile = Framing.GetTileSafely(i, j - grownLeaves);
								if (!leafTile.HasTile || leafTile.TileType == 367)
								{
									WorldGen.PlaceTile(i, j - grownLeaves, ModContent.TileType<Tiles.Marble.BloodLeaves>(), false, false, -1, 0);
									leafTile.TileType = (ushort)ModContent.TileType<Tiles.Marble.BloodLeaves>();
									leafTile.Slope = SlopeType.Solid;
									leafTile.IsHalfBlock = false;
								}
							}
							badTiles = 0;
							for (int CheckDown = 0; CheckDown < 12; CheckDown++)
							{
								Tile tempTile2 = Framing.GetTileSafely(i, j + CheckDown);
								if (tempTile2.HasTile || (int)(tempTile2.TileType) == ModContent.TileType<Tiles.Marble.BloodLeaves>() || tempTile2.WallType != 178)
								{
									badTiles++;
								}
							}
							if (badTiles <= 1)
							{
								int amountOfLeaves = WorldGen.genRand.Next(2, 5);
								for (int grownLeaves2 = 0; grownLeaves2 < amountOfLeaves; grownLeaves2++)
								{
									Tile leafTile2 = Framing.GetTileSafely(i, j + grownLeaves2);
									if (!leafTile2.HasTile)
									{
										WorldGen.PlaceTile(i, j + grownLeaves2, ModContent.TileType<Tiles.Marble.BloodLeaves>(), false, false, -1, 0);
										leafTile2.TileType = (ushort)ModContent.TileType<Tiles.Marble.BloodLeaves>();
										leafTile2.Slope = SlopeType.Solid;
										leafTile2.IsHalfBlock = false;
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
