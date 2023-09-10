using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon
{
	public class MathExtras
	{
		public static float TensionStep(float value1, float value2, float progress, float tensionProgressMax, float tensionAmount)
        {
			float tensionAccustomatedValue = (value1 + tensionAmount);
			float value;
			if (tensionProgressMax > progress)
            {
				value = MathHelper.SmoothStep(value1, tensionAccustomatedValue, (progress/tensionProgressMax));
            } else
            {
				value = MathHelper.SmoothStep(tensionAccustomatedValue, value2, ((progress - tensionProgressMax)/(1f - tensionProgressMax)));
            }

			return value;
        }



	}
}