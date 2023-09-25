using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class BloodiedVial : ModItem
	{
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("Gives a small chance to lifesteal from enemies");
        }
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 200;
            Item.buffType = ModContent.BuffType<Buffs.Potions.BloodiedVial>();
            Item.buffTime = 21600;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.WormTooth);
            recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ModContent.ItemType<Materials.BloodySpiderLeg>());
            recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}