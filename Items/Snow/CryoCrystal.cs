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

namespace Zylon.Items.Snow
{
	public class CryoCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cryo Crystal");
			Tooltip.SetDefault("'Each Cryo Crystal you hold makes you feel a bit better in the cold...'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 200;
			item.rare = 1;
			item.useStyle = 4;
		}
	}
}