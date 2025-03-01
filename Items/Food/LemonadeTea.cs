using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Zylon.Items.Food
{
	public class LemonadeTea : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 5;
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 32;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.maxStack = 9999;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed2;
            Item.buffTime = 13*3600;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
		}
        public override void UseAnimation(Player player) {
            player.AddBuff(BuffID.Sunflower, 13*3600);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(2);
			recipe.AddIngredient(ItemID.Lemonade);
			recipe.AddIngredient(ItemID.Teacup);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 2);
			recipe.AddTile(TileID.CookingPots);
			recipe.Register();
		}
	}
}