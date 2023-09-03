using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Tiles.Marble
{
	public class GloryGrasses : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileNoAttach[(int)Type] = true;
			Main.tileFrameImportant[(int)Type] = true;
			Main.tileCut[(int)Type] = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Glory Grass");
			AddMapEntry(new Color(110, 0, 59));
			DustType = 117;
			HitSound = SoundID.Grass;
			RegisterItemDrop(0);
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			this.ConfirmHold(i, j);
			if (resetFrame)
			{
				tile.TileFrameX = (short)(18 * Main.rand.Next(0, 4));
			}
			return true;
		}

		private void ConfirmHold(int i, int j)
		{
			if (!Main.tile[i, j - 1].HasTile || Main.tile[i, j - 1].IsHalfBlock || Main.tile[i, j - 1].Slope > SlopeType.Solid)
			{
				WorldGen.KillTile(i, j, false, false, false);
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
				}
			}
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = -2;
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 0)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}
