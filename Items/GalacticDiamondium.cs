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
	public class GalacticDiamondium : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Galactic Diamondium");
			Tooltip.SetDefault("'A shard of the Zylonian Mineral Extractor. Very valuable.'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 70000;
			item.rare = 11;
		}
	}
}