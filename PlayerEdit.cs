using Zylon;
using Zylon.Items;
using Zylon.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace Zylon
{
	public class PlayerEdit : ModPlayer
	{
		//public bool overridden;
		
		//public override void ResetEffects()
		//{
			//overridden = false;
		//}
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ItemType<Items.OtherSlappys.CopperSlappy>());
			item.stack = 1;
			items.Add(item);
			
			item = new Item();
			item.SetDefaults(ItemType<Items.Accessories.KaizoMedal>());
			item.stack = 1;
			items.Add(item);
			
			item = new Item();
			item.SetDefaults(ItemType<Items.ContagionalInfo>());
			item.stack = 1;
			items.Add(item);
		}
	}
}