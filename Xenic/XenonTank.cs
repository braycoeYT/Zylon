using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Xenic
{
	public class XenonTank : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenon Tank");
			Tooltip.SetDefault("Xenic Acid rapidly heals you instead of hurting you\nAll attacks have a chance of applying Xenic Acid to enemies");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4)); //first is speed, second is amount of frames
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 750000;
			item.rare = 11;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.xenicExpert = true;
		}
	}
}