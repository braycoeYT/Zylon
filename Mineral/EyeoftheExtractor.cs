using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class EyeoftheExtractor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Extractor");
			Tooltip.SetDefault("Increases jump speed by 500%\nDecreases Xenic Acid debuff damage by 25%\nKilling enemies causes them to drop galactic souls, which give you a powerful buff\nCancels negative effects of gemstone armor");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 750000;
			item.rare = 11;
			item.expert = true;
			item.defense = 2;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.mineralExpert = true;
			player.jumpSpeedBoost += 5f;
			player.allDamage += Math.Abs(player.velocity.X) / 100;
			player.statDefense += (int)Math.Abs(player.velocity.Y);
		}
	}
}