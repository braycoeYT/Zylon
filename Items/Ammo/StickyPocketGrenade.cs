using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class StickyPocketGrenade : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 12;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 6f;
			Item.value = 50;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.StickyPocketGrenade>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemType<PocketGrenade>(), 50);
			recipe.AddIngredient(ItemID.Gel);
			recipe.Register();
		}
	}
}