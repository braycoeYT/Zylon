using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	public class SpikySac : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiky Sac");
			Tooltip.SetDefault("When you get hurt, you unleash a barrage of empress spikes");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 1000000;
			item.rare = 7;
			item.expert = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();

			p.empressSpikes = true;
		}
	}
}