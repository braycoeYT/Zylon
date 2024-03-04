using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class LobsterBisque : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 22;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed3;
            Item.buffTime = 72000;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BowlofSoup);
			recipe.AddIngredient(ItemID.RockLobster);
			recipe.AddIngredient(ItemID.PixieDust);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>());
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>());
			recipe.AddTile(TileID.CookingPots);
			recipe.Register();
		}
	}
}