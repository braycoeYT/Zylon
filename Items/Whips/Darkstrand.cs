﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class Darkstrand : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DarkstrandDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.Darkstrand>(), 51, 4f, 6f, 40);
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 4, 60);
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}