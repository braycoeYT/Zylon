using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class PoisonousArrow : ModItem
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Poisonous Arrow");
			// Tooltip.SetDefault("'Not to be confused with venom arrows'");
        }
		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 0, 8);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<Projectiles.Ammo.PoisonousArrow>();
			Item.shootSpeed = 2f;
			Item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(150);
			recipe.AddIngredient(ItemID.WoodenArrow, 150);
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}   
}