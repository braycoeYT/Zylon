using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class MagmusHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A harp made of lava and creates sounds of fire...\nShoots fire notes that burn enemies'");
		}
		public override void SetDefaults() 
		{
			item.damage = 24;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 6400;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("FireNote");
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 5;
			item.holdStyle = 3;
			item.stack = 1;
			item.crit = 2;
			item.UseSound = SoundID.Item26;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}