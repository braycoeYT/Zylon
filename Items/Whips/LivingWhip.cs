﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class LivingWhip : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(LivingWhipDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.LivingWhip>(), 10, 1.75f, 6.5f);
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 17);
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 8);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}