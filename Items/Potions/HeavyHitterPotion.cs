using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class HeavyHitterPotion : ModItem
	{
        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
        public override void SetDefaults() {
            Item.width = 16;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
            Item.buffType = ModContent.BuffType<Buffs.Potions.HeavyHitter>();
            Item.buffTime = 25200;
        }
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddRecipeGroup("Zylon:AnyShadowScale");
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}