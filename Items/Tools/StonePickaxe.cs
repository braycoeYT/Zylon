using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class StonePickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2.25f;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.pick = 35;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 8);
			recipe.AddRecipeGroup("Wood", 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}