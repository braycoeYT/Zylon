using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class BloodRedHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'This harp is made with the blood of the ancient beast that started the crimson'");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 2700;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 3;
			item.holdStyle = 3;
			item.stack = 1;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}