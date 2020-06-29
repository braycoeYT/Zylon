using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Magentite
{
	public class MagentiteStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoot pink blastballs everywhere");
		}

		public override void SetDefaults() 
		{
			item.damage = 8;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 21000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("MagentaBolt");
			item.shootSpeed = 5f;
			item.noMelee = true;
			item.mana = 4;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}