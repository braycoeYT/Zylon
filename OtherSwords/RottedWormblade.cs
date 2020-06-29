using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Zylon.Items.OtherSwords
{
	public class RottedWormblade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Even a quick glance calls you to a rotting place, far and deep, hidden from the outside world.'");
		}

		public override void SetDefaults() 
		{
			item.damage = 61;
			item.melee = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 400000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 2;
			item.shoot = 307;
			item.shootSpeed = 6;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EyeOpener"));
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.Seashell, 4);
			recipe.AddIngredient(ItemID.WormTooth, 2);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}