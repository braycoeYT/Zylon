using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class EyeCandy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye Candy");
			Tooltip.SetDefault("The wrapper says that this is strawberry flavored.\nAfter taking damage, mana cost is halved");
		}

		public override void SetDefaults() {
			item.width = 58;
			item.height = 23;
			item.accessory = true;
			item.value = 42000;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.eyeCandy = true;
		}
	}
}