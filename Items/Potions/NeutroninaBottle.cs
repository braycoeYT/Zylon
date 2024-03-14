using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class NeutroninaBottle : ModItem
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
            Item.rare = ItemRarityID.Red;
            Item.value = 200;
            Item.buffType = ModContent.BuffType<Buffs.Potions.Neutronic>();
            Item.buffTime = 28800;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>());
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
    }
}