using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class OozingDart : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 18;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 0.5f;
			Item.value = Item.sellPrice(0, 0, 0, 3);
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.Ammo.OozingDart>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(75);
			recipe.AddIngredient(ItemType<Materials.Oozeberry>());
			recipe.Register();
		}
	}
}