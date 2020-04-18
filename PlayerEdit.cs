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
		
		public bool ZoneOblivion;
		public bool MarblePet;
		public bool UpgradeMeatball;
		
		public override void ResetEffects()
		{
			MarblePet = false;
			UpgradeMeatball = false;
		}
		
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ItemType<Items.OtherSlappys.PHOres.CopperSlappy>());
			item.stack = 1;
			items.Add(item);
			
			item = new Item();
			item.SetDefaults(ItemType<Items.Accessories.EyeThemed.KaizoMedal>());
			item.stack = 1;
			items.Add(item);
			
			item = new Item();
			item.SetDefaults(ItemType<Items.ContagionalInfo>());
			item.stack = 1;
			items.Add(item);
			
			if (Main.expertMode)
			{
				item = new Item();
				item.SetDefaults(ItemType<Items.VoidDream.NeozylsWrath>());
				item.stack = 1;
				items.Add(item);
			}
		}
		
		public override void UpdateBiomes()
		{
			ZoneOblivion = WorldEdit.oblivionTiles > 200;
		}
		
		public override bool CustomBiomesMatch(Player other) 
		{
			PlayerEdit modOther = other.GetModPlayer<PlayerEdit>();
			return ZoneOblivion == modOther.ZoneOblivion;
		}
		
		public override void CopyCustomBiomesTo(Player other)
		{
			PlayerEdit modOther = other.GetModPlayer<PlayerEdit>();
			modOther.ZoneOblivion = ZoneOblivion;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneOblivion;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneOblivion = flags[0];
		}

		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneOblivion)
			{
				return mod.GetTexture("OblivionMapBackground");
			}
			return null;
		}
	}
}