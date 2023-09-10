using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class DiskiteShrapnel : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("For use with the shrapnel gun");
        }
		public override void SetDefaults() {
			Item.damage = 3;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.DiskiteShrapnel>();
			Item.ammo = Item.type;
			Item.crit = 10;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(20);
			recipe.AddIngredient(ItemType<Materials.DiskiteCrumbles>(), 3);
			recipe.AddRecipeGroup("IronBar");
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}