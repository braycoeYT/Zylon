using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ContagionalAccessories
{
	public class EmptyVirusCapsule : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Empty Capsule");
            Tooltip.SetDefault("Perfect for containing stuff.");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 14;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item1;
            item.maxStack = 999;
            item.rare = 0;
            item.value = 200;
        }
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.SandBlock, 2);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}