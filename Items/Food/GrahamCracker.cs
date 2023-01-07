using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Food
{
	public class GrahamCracker : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Minor improvements to all stats");
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.maxStack = 999;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 18000;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Hay, 2);
			recipe.AddTile(TileID.CookingPots);
			recipe.Register();
		}
	}
}