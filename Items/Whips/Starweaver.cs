﻿using Zylon.Buffs.Whips;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class Starweaver : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(StarweaverDebuff.TagDamage);
		public override void SetDefaults() {
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Whips.Starweaver>(), 170, 4f, 8f);
			Item.rare = ItemRarityID.Red;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.value = Item.sellPrice(0, 10, 0, 0);
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentStardust, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}