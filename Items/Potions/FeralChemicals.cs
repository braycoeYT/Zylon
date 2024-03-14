using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class FeralChemicals : ModItem
	{
        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
        public override void SetDefaults() {
            Item.width = 32;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 200;
            Item.buffType = ModContent.BuffType<Buffs.Potions.Feral>();
            Item.buffTime = 28800;
        }
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddIngredient(ItemID.JungleSpores);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}