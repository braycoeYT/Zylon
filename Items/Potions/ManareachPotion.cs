using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class ManareachPotion : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Increases pickup range for mana stars\nDoes not stack with Celestial Magnet");
        }
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 200;
            Item.buffType = ModContent.BuffType<Buffs.Potions.Manareach>();
            Item.buffTime = 28800;
        }
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}