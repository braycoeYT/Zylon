using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Zylon
{
	public class WorldGenHelpers
	{
		public static void ForcedTileCreation(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f)
		{
			Vector2 Pos = new Vector2((float)i, (float)j);
			Vector2 OffsetPerLoop = new Vector2(speedX, speedY);
			for (int takenSteps = 0; takenSteps < steps; takenSteps++)
			{
				int XOffsetExtra = 0;
				while ((double)XOffsetExtra < (double)Math.Abs(OffsetPerLoop.X) + strength / 2.0)
				{
					int YOffsetExtra = 0;
					while ((double)YOffsetExtra < (double)Math.Abs(OffsetPerLoop.Y) + strength / 2.0)
					{
						Tile tile = Framing.GetTileSafely((int)Pos.X + XOffsetExtra, (int)Pos.Y + YOffsetExtra);
						if (tile != null)
						{
							if (addTile)
							{
								WorldGen.PlaceTile((int)Pos.X + XOffsetExtra, (int)Pos.Y + YOffsetExtra, type, false, false, -1, 0);
								tile.TileType = (ushort)type;
								tile.Slope = SlopeType.Solid;
							}
							else if (tile.HasTile)
							{
								tile.TileType = (ushort)type;
								tile.Slope = SlopeType.Solid;
							}
						}
						YOffsetExtra++;
					}
					XOffsetExtra++;
				}
				Pos += OffsetPerLoop;
				OffsetPerLoop -= OffsetPerLoop / (float)steps;
				strength -= strength / (double)((float)steps);
			}
		}
	}
}
