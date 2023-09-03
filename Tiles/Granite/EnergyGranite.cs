using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Tiles.Granite
{
	public class EnergyGranite : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[(int)Type] = true;
			Main.tileShine2[(int)Type] = true;
			Main.tileShine[(int)Type] = 500;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileSolid[(int)Type] = true;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(94, 101, 241));
			DustType = 228;
			HitSound = new SoundStyle?(new SoundStyle("Zylon/Sounds/Tiles/EnergyGraniteHit", SoundType.Sound)
			{
				Volume = 1f,
				PitchVariance = 0.6f,
				MaxInstances = 12
			});
			MineResist = 3f;
			MinPick = 62;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.6f;
			g = 0.6f;
			b = 0.6f;
		}
	}
}
