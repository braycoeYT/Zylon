using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class MudPie : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mud Pie"); //thought about giving it some special effect but couldn't think of any good ones...
			// Tooltip.SetDefault("Minor improvements to all stats\n'Is it chocolate or mud? Only one way to find out!'");
		}
		public override void SetDefaults() {
			Item.width = 38;
			Item.height = 24;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 0, 1);
			Item.rare = ItemRarityID.Gray;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 46800;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MudBlock, 15);
            recipe.AddIngredient(ModContent.ItemType<CocoaBeans>());
			recipe.AddCondition(Condition.NearWater);
            recipe.Register();
		}
	}
}