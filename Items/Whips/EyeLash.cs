﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class EyeLash : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(EyeLashDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.EyeLash>(), 14, 1f, 8f);
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 72);
		}
		public override bool MeleePrefix() {
			return true;
		}
	}
}