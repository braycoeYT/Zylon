using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
	public class StealthPotion : ModItem
	{
        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
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
            Item.buffType = ModContent.BuffType<Buffs.Potions.Stealthy>();
            Item.buffTime = 14400;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Silk, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.Fish.PaintedGlassTetra>());
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}