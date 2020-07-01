using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Potions
{
	public class RockyPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives a ton of defense at the cost of attack and speed.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 28;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 1;
            item.value = 250;
            item.buffType = mod.BuffType("Rocky");
            item.buffTime = 21600;
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.GraniteBlock, 5);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}