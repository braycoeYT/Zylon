using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class ShadowHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'This object may or may not be linked to chronic ear pain'");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 2700;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 3.5f;
			item.noMelee = true;
			item.mana = 5;
			item.holdStyle = 3;
			item.stack = 1;
			item.crit = 2;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}