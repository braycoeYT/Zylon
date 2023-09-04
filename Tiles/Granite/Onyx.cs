using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Zylon.Items.Materials;

namespace Zylon.Tiles.Granite
{
	public class Onyx : ModTile
	{
		private const int FrameWidth = 18;

		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)Type] = true;
			Main.tileObsidianKill[(int)Type] = true;
			Main.tileCut[(int)Type] = false;
			Main.tileNoFail[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			TileID.Sets.ReplaceTileBreakUp[(int)Type] = true;
			TileID.Sets.IgnoredInHouseScore[(int)Type] = true;
			TileID.Sets.IgnoredByGrowingSaplings[(int)Type] = true;
			Main.tileSpelunker[(int)Type] = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Onyx");
			AddMapEntry(new Color(140, 100, 177), name);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				TileID.Granite,
				TileID.GraniteBlock,
				ModContent.TileType<EnergyGranite>(),
				ModContent.TileType<OnyxCrystals>()
			};
			TileObjectData.newTile.AnchorAlternateTiles = new int[0];
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.addTile((int)Type);
			MineResist = 1f;
			HitSound = new SoundStyle?(new SoundStyle("Zylon/Sounds/Tiles/OnyxBreak", SoundType.Sound)
			{
				Volume = 1f,
				PitchVariance = 0.6f,
				MaxInstances = 12
			});
			DustType = 36;
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = -2;
		}

		public override IEnumerable<Item> GetItemDrops(int i, int j)
		{
			yield return new Item(ModContent.ItemType<Items.Materials.OnyxShard>(), Main.rand.Next(1, 4));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			float LightAmount = Main.rand.NextFloat(0.35f, 0.4f);
			r = LightAmount;
			g = LightAmount;
			b = LightAmount;
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D tileTexture = TextureAssets.Tile[(int)Type].Value;
			Texture2D bloom = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");
			SpriteEffects effects = SpriteEffects.None;
			if (i % 2 == 0)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange);
			Vector2 drawPos = new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y));
			Vector2 bloomDrawPos = drawPos + zero + new Vector2(8f, 8f);
			Color bloomColor = new Color(216, 180, 232);
			tile.TileFrameX = (short)(FrameWidth * (i % 3));
			spriteBatch.Draw(bloom, bloomDrawPos, null, bloomColor * 0.08f, 0f, bloom.Size() / 2f, 0.3f, effects, 0f);
			spriteBatch.Draw(bloom, bloomDrawPos, null, bloomColor * 0.08f, 0f, bloom.Size() / 2f, 0.5f, effects, 0f);
			float time = Main.GlobalTimeWrappedHourly;
			time += (float)(j + i) * 1.735f;
			time %= 4f;
			time /= 2f;
			if (time >= 1f)
			{
				time = 2f - time;
			}
			float bloomColorMulti = MathHelper.SmoothStep(0f, 1f, time / 1.5f);
			Color bloomColorFinal = bloomColor * 0.15f * bloomColorMulti;
			spriteBatch.Draw(bloom, bloomDrawPos + new Vector2(0f, -40f), null, bloomColorFinal, 0f, bloom.Size() / 2f, new Vector2(0.2f, 0.7f), effects, 0f);
			spriteBatch.Draw(bloom, bloomDrawPos + new Vector2(0f, -40f), null, bloomColorFinal, 0f, bloom.Size() / 2f, new Vector2(0.2f, 1.2f), effects, 0f);
			spriteBatch.Draw(tileTexture, drawPos + zero, new Rectangle((int)(tile.TileFrameX), (int)(tile.TileFrameY), 16, 20), Color.White, 0f, default(Vector2), 1f, effects, 0f);
			if (Main.rand.NextBool(90) && Main.netMode != NetmodeID.Server)
			{
				Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 10, 10, ModContent.DustType<OnyxDust>(), 0f, 0f, 0, default(Color), 1.1f);
			}
			return false;
		}
	}
}
