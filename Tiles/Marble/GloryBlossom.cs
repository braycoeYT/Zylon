using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Zylon.Items.Materials;

namespace Zylon.Tiles.Marble
{
	public class GloryBlossom : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileObsidianKill[(int)base.Type] = true;
			Main.tileCut[(int)base.Type] = false;
			Main.tileNoFail[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			TileID.Sets.ReplaceTileBreakUp[(int)base.Type] = true;
			TileID.Sets.IgnoredInHouseScore[(int)base.Type] = true;
			TileID.Sets.IgnoredByGrowingSaplings[(int)base.Type] = true;
			Main.tileSpelunker[(int)base.Type] = true;
			TileMaterials.SetForTileId(base.Type, TileMaterials._materialsByName["Plant"]);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Glory Blossom");
			AddMapEntry(new Color(255, 126, 49), name);
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				367,
				357,
				ModContent.TileType<BloodLeaves>()
			};
			TileObjectData.newTile.AnchorAlternateTiles = new int[]
			{
				78,
				380
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile((int)base.Type);
			base.HitSound = new SoundStyle?(SoundID.Grass);
			base.DustType = 117;
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = -2;
		}

		public override bool Drop(int i, int j)
		{
			Vector2 worldPosition = new Vector2((float)i, (float)j).ToWorldCoordinates(8f, 8f);
			int petalItem = ModContent.ItemType<GloryPetals>();
			int petalAmount = Main.rand.Next(1, 4);
			EntitySource_TileBreak source = new EntitySource_TileBreak(i, j, null);
			if (petalItem > 0 && petalAmount > 0)
			{
				Item.NewItem(source, worldPosition, petalItem, petalAmount, false, 0, false, false);
			}
			return false;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			float LightMulti = 0.2f;
			r = 1f * LightMulti;
			g = 0.494117647f * LightMulti;
			b = 0.192156866f * LightMulti;
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Texture2D tileTexture = TextureAssets.Tile[(int)base.Type].Value;
			Texture2D bloom = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");
			SpriteEffects effects = 0;
			if (i % 2 == 0)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange);
			Vector2 drawPos;
			drawPos = new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y));
			Vector2 bloomDrawPos = drawPos + zero + new Vector2(8f, 8f);
			float time = Main.GlobalTimeWrappedHourly;
			time += (float)(j + i) * 1.735f;
			time %= 4f;
			time /= 2f;
			if (time >= 1f)
			{
				time = 2f - time;
			}
			Color bloomColor = Color.Lerp(new Color(255, 126, 49), new Color(255, 49, 49), time / 1.5f);
			float bloomSize = MathHelper.SmoothStep(0.5f, 2.2f, time / 1.5f);
			spriteBatch.Draw(bloom, bloomDrawPos, null, bloomColor * 0.18f, 0f, bloom.Size() / 2f, 0.3f * bloomSize, 0, 0f);
			spriteBatch.Draw(bloom, bloomDrawPos, null, bloomColor * 0.18f, 0f, bloom.Size() / 2f, 0.5f * bloomSize, 0, 0f);
			spriteBatch.Draw(tileTexture, drawPos + zero, new Rectangle((int)(tile.TileFrameX), (int)(tile.TileFrameY), 16, 20), Color.White, 0f, default(Vector2), 1f, effects, 0f);
			return false;
		}
	}
}
