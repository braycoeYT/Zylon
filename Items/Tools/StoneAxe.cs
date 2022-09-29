using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class StoneAxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 3;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 28;
			Item.useTime = 29;
			Item.useAnimation = 29;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.75f;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.axe = 7;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 6);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}