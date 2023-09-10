using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Tiles.Granite
{
	public class OnyxSystem : ModSystem
	{
		public override void PostUpdateWorld()
		{
			float tries = (float)((double)(Main.maxTilesX * Main.maxTilesY) * WorldGen.GetWorldUpdateRate() * 2.9999999242136255E-05);
			int scale = 151;
			int chance = (int)MathHelper.Lerp((float)scale, (float)scale * 2.8f, MathHelper.Clamp((float)Main.maxTilesX / 4200f - 1f, 0f, 1f));
			if (Main.rand.NextBool(chance * 100 / (int)tries))
			{
				AttemptOnyx();
			}
		}

		public static void AttemptOnyx()
		{
			int x = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
			int y = WorldGen.genRand.Next(20, Main.maxTilesY - 20);
			while (y < Main.maxTilesY - 20 && !Main.tile[x, y].HasTile)
			{
				y++;
			}
			if (Main.tile[x, y - 1].HasTile || !Main.tile[x, y].HasUnactuatedTile || Main.tile[x, y].IsHalfBlock || Main.tile[x, y].Slope != SlopeType.Solid)
			{
				return;
			}
			if (Main.tile[x, y].TileType != 368 && (int)(Main.tile[x, y].TileType) != ModContent.TileType<EnergyGranite>() && Main.tile[x, y].TileType != 369 && (int)(Main.tile[x, y].TileType) != ModContent.TileType<OnyxCrystals>())
			{
				return;
			}
			if (Main.tile[x, y - 1].LiquidType > 0)
			{
				return;
			}
			int offset = 15;
			int alchMin = 5;
			int alchCount = 0;
			offset = (int)((float)offset * ((float)Main.maxTilesX / 4200f));
			int num = Utils.Clamp<int>(x - offset, 4, Main.maxTilesX - 4);
			int rightPart = Utils.Clamp<int>(x + offset, 4, Main.maxTilesX - 4);
			int topPart = Utils.Clamp<int>(y - offset, 4, Main.maxTilesY - 4);
			int botPart = Utils.Clamp<int>(y + offset, 4, Main.maxTilesY - 4);
			for (int i = num; i <= rightPart; i++)
			{
				for (int j = topPart; j <= botPart; j++)
				{
					if (Main.tileAlch[(int)(Main.tile[i, j].TileType)])
					{
						alchCount++;
					}
				}
			}
			if (alchCount >= alchMin)
			{
				return;
			}
			WorldGen.PlaceTile(x, y - 1, ModContent.TileType<Onyx>(), true, false, -1, 0);
			if (Main.tile[x, y - 1].HasTile && Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendTileSquare(-1, x, y - 1, TileChangeType.None);
			}
		}
	}
}
