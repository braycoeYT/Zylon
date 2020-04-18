using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.VoidDream
{
	public class MeatballSpecial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meatball Special");
			Tooltip.SetDefault("Always well fed\nRarely you receive short random slowing debuffs because of this infinite pasta\nMeatballs are replaced by big meatballs\nBig meatballs venom enemies instead of poison\nVoid Dream");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 45000;
			item.rare = 3;
			item.expert = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(26, 15, true);
			if (Main.rand.NextFloat() < .000305f)
			player.AddBuff(46, 60, false);
			if (Main.rand.NextFloat() < .000305f)
			player.AddBuff(32, 60, false);
		
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();

			p.UpgradeMeatball = true;
		}
	}
}