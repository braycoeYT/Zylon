using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class VenomDart : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 0, 0, 5);
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.Ammo.VenomDart>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(ItemID.VialofVenom);
			recipe.Register();
		}
	}
}