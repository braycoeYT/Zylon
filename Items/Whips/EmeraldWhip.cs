﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class EmeraldWhip : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(EmeraldWhipDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.EmeraldWhip>(), 13, 2.25f, 7f);
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1);
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Emerald, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}