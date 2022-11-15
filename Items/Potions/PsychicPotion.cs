using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class PsychicPotion : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Greatly increases mana regen, but decreases your max life");
        }
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 200;
            Item.buffType = ModContent.BuffType<Buffs.Potions.Psychic>();
            Item.buffTime = 25200;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ModContent.ItemType<Materials.Fish.LabyrinthFish>());
			recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}