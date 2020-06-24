using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class PlanteraHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Plantera's Harp");
			Tooltip.SetDefault("Shoots poisonous notes");
		}
		public override void SetDefaults() 
		{
			item.damage = 56;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 350000;
			item.rare = 7;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("PoisonSound");
			item.shootSpeed = 11f;
			item.noMelee = true;
			item.mana = 5;
			item.holdStyle = 3;
			item.stack = 1;
			item.UseSound = SoundID.Item26;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("VinewireHarp"));
			recipe.AddIngredient(mod.ItemType("PlanteraTooth"), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}