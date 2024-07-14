using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class ElementalGooshot : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 0, 2);
			Item.rare = ItemRarityID.Lime;
			Item.shoot = ProjectileType<Projectiles.Ammo.ElementalGooshot>();
			Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Seed, 75);
			recipe.AddIngredient(ItemType<Materials.ElementalGoop>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}