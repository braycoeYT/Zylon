using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.Items.Materials;

namespace Zylon.Tiles.Granite
{
	public class OnyxCrystals : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileShine2[(int)Type] = true;
			Main.tileShine[(int)Type] = 500;
			Main.tileSolid[(int)Type] = true;
			Main.tileMerge[(int)Type][TileID.Granite] = true;
			Main.tileMerge[TileID.Granite][(int)Type] = true;
			TileID.Sets.ChecksForMerge[(int)Type] = true;
			AddMapEntry(new Color(140, 100, 177));
			DustType = 36;
			RegisterItemDrop(ModContent.ItemType<OnyxShard>());
			HitSound = new SoundStyle?(new SoundStyle("Zylon/Sounds/Tiles/EnergyGraniteHit", SoundType.Sound)
			{
				Volume = 1f,
				PitchVariance = 0.6f,
				MaxInstances = 12
			});
			MineResist = 1.5f;
		}
	}
}
