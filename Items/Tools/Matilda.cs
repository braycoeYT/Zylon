using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class Matilda : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 29;
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.5f;
			Item.value = Item.sellPrice(0, 0, 89);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.axe = 17;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.BlueBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.GreenBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.PinkBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}