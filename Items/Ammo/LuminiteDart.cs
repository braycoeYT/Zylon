using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class LuminiteDart : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 18;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 0, 0, 2);
			Item.rare = ItemRarityID.Cyan;
			Item.shoot = ProjectileType<Projectiles.Ammo.LuminiteDart>();
			Item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(333);
			recipe.AddIngredient(ItemID.LunarBar);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}