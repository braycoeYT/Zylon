using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Tiles.Marble
{
	public class BloodLeafFall : ModGore
	{
		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 0;
		}

		public override void OnSpawn(Gore gore, IEntitySource source)
		{
			gore.numFrames = 8;
			gore.frame = 0;
		}
		public override bool Update(Gore gore)
		{
			if (gore.alpha % 12 == 0)
			{
				gore.frame++;
			}
			gore.frameCounter += 1;
			if (gore.frameCounter % 2 == 0)
			{
				gore.alpha++;
				gore.frameCounter = 0;
			}
			if (gore.frame >= gore.numFrames)
			{
				gore.frame = 0;
			}
			if (gore.alpha >= 255)
			{
				gore.active = false;
			}
			if (gore.alpha % 80 <= 40)
			{
				gore.position += new Vector2(MathHelper.SmoothStep(-0.6f, 0.6f, (float)(gore.alpha % 40) / 40f), MathExtras.TensionStep(0.4f, 0.4f, (float)(gore.alpha % 40) / 40f, 0.5f, 0.3f));
				gore.rotation = MathHelper.SmoothStep(-1.57079637f, 1.57079637f, (float)(gore.alpha % 40) / 40f);
			}
			else
			{
				gore.position += new Vector2(MathHelper.SmoothStep(0.6f, -0.6f, (float)((gore.alpha - 40) % 40) / 40f), MathExtras.TensionStep(0.4f, 0.4f, (float)(gore.alpha % 40) / 40f, 0.5f, 0.3f));
				gore.rotation = MathHelper.SmoothStep(1.57079637f, -1.57079637f, (float)((gore.alpha - 40) % 40) / 40f);
			}
			gore.position += new Vector2(-0.24f, 0f);
			return false;
		}
	}
}
