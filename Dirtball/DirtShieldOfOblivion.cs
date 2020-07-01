using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Dirtball
{
	public class DirtShieldOfOblivion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dirt Shield of Oblivion");
			Tooltip.SetDefault("When the owner has low health, the dirt casing increases damage reduction by 10%");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 50000;
			item.rare = -1;
			item.expert = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLifeMax2 / 2 > player.statLife)
				player.endurance += 0.1f;
		}
	}
}