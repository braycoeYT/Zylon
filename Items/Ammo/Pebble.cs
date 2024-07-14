using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class Pebble : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.height = 10;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.Pebble>();
			//Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Dart;
			Item.crit = 4;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.StoneBlock);
			recipe.Register();
		}
	}
}