using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Carnallite
{
	public class Herbarage : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts regular arrows to rose arrows that can confuse enemies");
		}
		public override void SetDefaults()  {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 19;
			item.useTime = 19;
			item.damage = 76;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 2, 75, 0);
			item.rare = ItemRarityID.Yellow;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ProjectileID.WoodenArrowFriendly) {
				type = mod.ProjectileType("RoseArrow");
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CarnalliteBar"), 12);
			recipe.AddIngredient(mod.ItemType("FloralUndergrowth"), 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}