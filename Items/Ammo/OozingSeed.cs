using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class OozingSeed : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("For use with blowpipes\nOn death, leaves a lasting ooze cloud");
        }
		public override void SetDefaults() {
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0.5f;
			Item.value = Item.sellPrice(0, 0, 0, 3);
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.Ammo.OozingSeed>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(75);
			recipe.AddIngredient(ItemID.Seed, 75);
			recipe.AddIngredient(ItemType<Materials.Oozeberry>());
			recipe.Register();
		}
	}
}