using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Tiles.Granite
{
	public class EnergizedStone : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[(int)Type] = false;
			Main.tileFrameImportant[(int)Type] = true;
			Main.tileSolid[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			Main.tileSpelunker[(int)Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Energized Stone");
			AddMapEntry(new Color(94, 101, 241), name);
			DustType = 228;
			ItemDrop = ModContent.ItemType<Items.Materials.EnergizedStone>();
			HitSound = new SoundStyle?(new SoundStyle("Zylon/Sounds/Tiles/EnergizedStoneHit", SoundType.Sound)
			{
				Volume = 1f,
				PitchVariance = 0.6f,
				MaxInstances = 12
			});
			MineResist = 7f;
			MinPick = 62;
		}

		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Texture2D tileTexture = TextureAssets.Tile[(int)base.Type].Value;
			Texture2D bloom = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/Glow120_120");
			Texture2D RayofLight = (Texture2D)ModContent.Request<Texture2D>("Zylon/Assets/Bloom/RayOfLight");
			SpriteEffects effects = 0;
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange);
			Vector2 drawPos = new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y));
			Vector2 bloomDrawPos = drawPos + zero + new Vector2(8f, 8f);
			spriteBatch.Draw(bloom, bloomDrawPos, null, Color.White * 0.1f, 0f, bloom.Size() / 2f, 0.5f, effects, 0f);
			spriteBatch.Draw(bloom, bloomDrawPos, null, Color.White * 0.1f, 0f, bloom.Size() / 2f, 0.3f, effects, 0f);
			spriteBatch.Draw(tileTexture, drawPos + zero, null, Color.White, 0f, default(Vector2), 1f, effects, 0f);
			float RayRotationValue = Main.GlobalTimeWrappedHourly;
			spriteBatch.Draw(RayofLight, bloomDrawPos, null, Color.White * 0.1f, RayRotationValue, bloom.Size() / 2f, 0.7f, effects, 0f);
			spriteBatch.Draw(RayofLight, bloomDrawPos, null, Color.White * 0.1f, RayRotationValue / 1.5f, bloom.Size() / 2f, 0.55f, effects, 0f);
			spriteBatch.Draw(RayofLight, bloomDrawPos, null, Color.White * 0.1f, RayRotationValue / 2f, bloom.Size() / 2f, 0.45f, effects, 0f);
			spriteBatch.Draw(RayofLight, bloomDrawPos, null, Color.White * 0.1f, RayRotationValue / 3f, bloom.Size() / 2f, 0.6f, effects, 0f);
			return false;
		}
	}
}
