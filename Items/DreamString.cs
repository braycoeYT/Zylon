using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class DreamString : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'It resembles some sort of septuple helix and can grant dreams'");
		}

		public override void SetDefaults() 
		{
			item.maxStack = 999;
			item.value = 2000;
		}
	}
}