using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class ApathyPotion : ModItem
	{
        public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 20;
		}
        public override void SetDefaults() {
            Item.width = 16;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<Magenta>();
            Item.value = Item.sellPrice(0, 0, 10);
            Item.buffType = ModContent.BuffType<Buffs.Potions.Apathy>();
            Item.buffTime = 54000;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(3);
			recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BottledHoney);
            recipe.AddIngredient(ModContent.ItemType<BottledLava>());
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>());
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}