using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class BouncyPocketGrenade : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Nothing's more painful than spilling them all over the floor...'\nFor use with blowpipes");
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
			Item.shoot = ProjectileType<Projectiles.Ammo.BouncyPocketGrenade>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemType<PocketGrenade>(), 50);
			recipe.AddIngredient(ItemID.PinkGel);
			recipe.Register();
		}
	}
}