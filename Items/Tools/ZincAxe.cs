using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class ZincAxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 6;
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 32;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.6f;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.axe = 8;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 8);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}