﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class Giegue : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GiegueDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.Giegue>(), 129, 2.5f, 10f);
			Item.rare = ItemRarityID.Yellow;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.value = Item.sellPrice(0, 6, 19);
		}
		public override bool MeleePrefix() {
			return true;
		}
	}
}