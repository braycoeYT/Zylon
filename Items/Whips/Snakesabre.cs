﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class Snakesabre : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SnakesabreDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.Snakesabre>(), 245, 6f, 8.5f);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.value = Item.sellPrice(0, 15);
		}
		public override bool MeleePrefix() {
			return true;
		}
	}
}