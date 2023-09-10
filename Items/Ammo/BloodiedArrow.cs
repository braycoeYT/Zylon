using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class BloodiedArrow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Pierces multiple times");
		}
		public override void SetDefaults() {
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 0, 8);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<Projectiles.Ammo.BloodiedArrow>();
			Item.shootSpeed = 2f;
			Item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.WoodenArrow, 5);
			recipe.AddIngredient(ItemType<Materials.BloodySpiderLeg>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}   
}