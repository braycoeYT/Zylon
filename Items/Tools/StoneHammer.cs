using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class StoneHammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 33;
			Item.useAnimation = 33;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.75f;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.hammer = 35;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 8);
			recipe.AddRecipeGroup("Wood", 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}