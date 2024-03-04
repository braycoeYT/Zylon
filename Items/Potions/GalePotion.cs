using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class GalePotion : ModItem
	{
        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.buffType = ModContent.BuffType<Buffs.Potions.Gale>();
            Item.buffTime = 28800;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>());
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}