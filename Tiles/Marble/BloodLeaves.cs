using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Tiles.Marble
{
	public class BloodLeaves : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileMerge[(int)Type][TileID.Marble] = true;
			Main.tileMerge[TileID.Marble][(int)Type] = true;
			TileID.Sets.ChecksForMerge[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(140, 26, 89), name);
			DustType = 117;
			HitSound = new SoundStyle?(SoundID.Grass);
			MineResist = 0.5f;
			RegisterItemDrop(0);
		}
		
		public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
		{
			if (!Main.tile[i, j + 2].HasTile && Main.rand.NextBool(270) && Main.netMode != NetmodeID.Server)
			{
				Gore.NewGore(new EntitySource_TileBreak(i, j, null), new Vector2((float)(i * 16), (float)(j * 16 + 8)), new Vector2(0f, 0f), ModContent.GoreType<BloodLeafFall>(), 1f);
			}
		}

		public override bool CanDrop(int i, int j)
		{
			return false;
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			return base.TileFrame(i, j, ref resetFrame, ref noBreak);
		}
	}
}
