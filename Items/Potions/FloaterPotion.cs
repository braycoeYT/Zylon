using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class FloaterPotion : ModItem
	{
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("Increases max wingtime by a second");
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
            Item.buffType = ModContent.BuffType<Buffs.Potions.Floater>();
            Item.buffTime = 43200;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>());
			recipe.AddIngredient(ItemID.Feather);
			recipe.AddIngredient(ItemID.SoulofFlight);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}