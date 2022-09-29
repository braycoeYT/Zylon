using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class Smore : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("S'more");
			Tooltip.SetDefault("Medium improvements to all stats\n'I'd get s'more puns, but there are none left...'");
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 24;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed2;
            Item.buffTime = 46800;
			Item.potion = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GrahamCracker>(), 2);
			recipe.AddIngredient(ModContent.ItemType<CocoaBeans>());
			recipe.AddIngredient(ItemID.CookedMarshmallow);
			recipe.AddTile(TileID.Campfire);
			recipe.Register();
		}
	}
}