using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Potions
{
    public class NeutroninaBottle : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Neutron in a Bottle");
            Tooltip.SetDefault("When above half life, increases damage by 10% but decreases defense by 10\nWhen below half life, increases defense by 10 but decreases damage by 10%\nPositive effects are halved if an ironskin or wrath/rage potion is active (to their respective stats)");
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