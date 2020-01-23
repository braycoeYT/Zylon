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
	public class ElementamaxSludge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Elementamax Sludge");
			Tooltip.SetDefault("'Overloaded with elemental power'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 999;
			item.value = 3419;
			item.rare = 7;
		}
	}
}