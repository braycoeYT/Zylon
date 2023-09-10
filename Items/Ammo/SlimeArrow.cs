using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class SlimeArrow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Slimes struck enemies");
		}
		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 0, 3);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<Projectiles.Ammo.SlimeArrow>();
			Item.shootSpeed = 2f;
			Item.ammo = AmmoID.Arrow;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(200);
			recipe.AddIngredient(ItemID.WoodenArrow, 200);
			recipe.AddIngredient(ItemType<Materials.SlimyCore>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}   
}