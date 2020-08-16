using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Potions
{
	public class StealthPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased movement speed, ranged damage, and you have a chance to dodge attacks\nDodging doesn't stack with the black belt");
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
            item.value = 390;
            item.buffType = mod.BuffType("Stealthy");
            item.buffTime = 14400;
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Silk, 1);
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}