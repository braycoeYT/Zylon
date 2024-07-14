using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class AdeniteShrapnel : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 3;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.AdeniteShrapnel>();
			Item.ammo = Item.type;
			Item.crit = 10;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(150);
			recipe.AddIngredient(ItemType<Materials.AdeniteCrumbles>(), 2);
			recipe.AddRecipeGroup("IronBar");
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}