using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Magentite
{
	public class MagentiteHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Quite a strong harp");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.knockBack = 0.5f;
			item.value = 21000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 4.5f;
			item.noMelee = true;
			item.mana = 8;
			item.holdStyle = 3;
			item.stack = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}