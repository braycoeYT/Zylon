using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Tiles.Marble
{
	public class GloryVines : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileNoAttach[(int)Type] = true;
			Main.tileFrameImportant[(int)Type] = true;
			Main.tileCut[(int)Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Glory Vine");
			AddMapEntry(new Color(110, 0, 59));
			DustType = 117;
			HitSound = new SoundStyle?(SoundID.Grass);
			ItemDrop = 0;
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			Tile tile = Framing.GetTileSafely(i, j);
			ConfirmHold(i, j);
			if (Main.tile[i, j + 1].TileType == base.Type)
			{
				tile.TileFrameY = 0;
			}
			else
			{
				tile.TileFrameY = 18;
			}
			if (resetFrame)
			{
				tile.TileFrameX = (short)(18 * Main.rand.Next(0, 8));
			}
			return true;
		}

		private void ConfirmHold(int i, int j)
		{
			if (Main.tile[i, j - 1].TileType != Type && (!Main.tile[i, j - 1].HasTile || Main.tile[i, j - 1].IsHalfBlock || Main.tile[i, j - 1].Slope > SlopeType.Solid))
			{
				WorldGen.KillTile(i, j, false, false, false);
				int offset = 20;
				while (offset > 0 && Framing.GetTileSafely(i, j + offset).TileType == Type)
				{
					WorldGen.KillTile(i, j + offset, false, false, false);
					offset--;
				}
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

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D tileTexture = TextureAssets.Tile[(int)Type].Value;
			SpriteEffects effects = 0;
			Rectangle frame = new Rectangle((int)(tile.TileFrameX), (int)(tile.TileFrameY), 16, 16);
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange);
			Vector2 drawPos = new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y));
			float time = Main.GlobalTimeWrappedHourly;
			time += (float)(j + i) * 0.5f;
			time %= 4f;
			time /= 2f;
			if (time >= 1f)
			{
				time = 2f - time;
			}
			drawPos.X += MathHelper.SmoothStep(-4f, 4f, time / 2f);
			drawPos.Y += MathHelper.SmoothStep(-1f, 1f, time / 2f);
			spriteBatch.Draw(tileTexture, drawPos + zero + new Vector2(0f, -4f), frame, Lighting.GetColor(i, j), 0f, default, 1f, effects, 0f);
			spriteBatch.Draw(tileTexture, drawPos + zero, frame, Lighting.GetColor(i, j), 0f, default, 1f, effects, 0f);
			return false;
		}

		public override void RandomUpdate(int i, int j)
		{
			if (!Framing.GetTileSafely(i, j + 1).HasTile && Main.rand.NextBool(12))
			{
				int VineCount = 0;
				int UpAmount = 0;
				while (UpAmount < 12 && Main.tile[i, j - UpAmount].TileType == base.Type)
				{
					VineCount++;
					if (VineCount >= 10)
					{
						return;
					}
					UpAmount++;
				}
				WorldGen.PlaceTile(i, j + 1, (int)base.Type, true, false, -1, 0);
				WorldGen.TileFrame(i, j, true, false);
				if (Main.tile[i, j].HasTile && Main.netMode != NetmodeID.SinglePlayer)
				{
					NetMessage.SendTileSquare(-1, i, j, TileChangeType.None);
					NetMessage.SendTileSquare(-1, i, j + 1, TileChangeType.None);
				}
			}
		}
	}
}
