using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Zylon.Tiles.Furniture
{
	public class SoulofByteinaBottle : ModTile
	{
		public override void SetStaticDefaults() {
			// Properties
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoAttach[Type] = true;
			TileID.Sets.MultiTileSway[Type] = true;
			Main.tileLavaDeath[Type] = true;

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.addTile(Type);

			// Etc
			LocalizedText name = CreateMapEntryName();

			AddMapEntry(new Color(160, 255, 159), name);

			AnimationFrameHeight = 36;
		}
		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) {
			Tile tile = Main.tile[i, j];

			if (TileObjectData.IsTopLeft(tile)) {
				Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileDrawing.TileCounterType.MultiTileVine);
			}

			return false;
		}
        public override void AdjustMultiTileVineParameters(int i, int j, ref float? overrideWindCycle, ref float windPushPowerX, ref float windPushPowerY, ref bool dontRotateTopTiles, ref float totalWindMultiplier, ref Texture2D glowTexture, ref Color glowColor) {
            overrideWindCycle = 1f;
			windPushPowerY = 0;
        }
        public override void AnimateTile(ref int frame, ref int frameCounter) {
            if (++frameCounter >= 6) {
				frameCounter = 0;
				if (++frame >= 8)
					frame = 0;
			}
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 1/255f;
			g = 1f;
			b = 0f;
		}
	}
}