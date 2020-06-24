using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class WoodenHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Play a sweet melody with this 100% wooden harp - even the strings (ouch)!'");
		}

		public override void SetDefaults() 
		{
			item.damage = 6;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 50;
			item.rare = 0;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 4.5f;
			item.noMelee = true;
			item.mana = 4;
			item.holdStyle = 3;
			item.stack = 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}