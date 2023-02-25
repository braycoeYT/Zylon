using System;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Zylon.Tiles;

namespace Zylon.WorldGeneration
{
	public class ZylonOnyxPass : GenPass
	{
		public ZylonOnyxPass(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Growing onyx";
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Framing.GetTileSafely(i, j);
					if ((tile.TileType == 368 || tile.TileType == 369 || (int)(tile.TileType) == ModContent.TileType<Tiles.Granite.OnyxCrystals>()) && !Main.tile[i, j - 1].HasTile && Main.tile[i, j - 1].LiquidType <= 0 && tile.HasUnactuatedTile && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && WorldGen.genRand.NextBool(7))
					{
						WorldGen.PlaceTile(i, j - 1, ModContent.TileType<Tiles.Granite.Onyx>(), false, false, -1, 0);
						if (WorldGen.genRand.NextBool(3))
						{
							int CrystalSize = WorldGen.genRand.Next(3, 6);
							for (int HorizontalTileReplacement = 0; HorizontalTileReplacement < CrystalSize; HorizontalTileReplacement++)
							{
								Tile replaceTile = Framing.GetTileSafely(i + HorizontalTileReplacement - CrystalSize / 2, j);
								if (replaceTile.TileType == 368)
								{
									replaceTile.TileType = (ushort)ModContent.TileType<Tiles.Granite.OnyxCrystals>();
								}
							}
							for (int VerticalTileReplacement = 0; VerticalTileReplacement < CrystalSize; VerticalTileReplacement++)
							{
								Tile replaceTile2 = Framing.GetTileSafely(i, j + VerticalTileReplacement - CrystalSize / 2);
								if (replaceTile2.TileType == 368)
								{
									replaceTile2.TileType = (ushort)ModContent.TileType<Tiles.Granite.OnyxCrystals>();
								}
							}
							if (WorldGen.genRand.NextBool(2) && Main.tile[i + 1, j + 1].TileType == 368)
							{
								Main.tile[i + 1, j + 1].TileType = (ushort)ModContent.TileType<Tiles.Granite.OnyxCrystals>();
							}
							if (WorldGen.genRand.NextBool(2) && Main.tile[i - 1, j + 1].TileType == 368)
							{
								Main.tile[i - 1, j + 1].TileType = (ushort)ModContent.TileType<Tiles.Granite.OnyxCrystals>();
							}
						}
					}
				}
			}
		}
	}
}
