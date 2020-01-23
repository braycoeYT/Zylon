using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class TacticalNucleusStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Shoots an infested bolt of destruction'");
		}

		public override void SetDefaults() 
		{
			item.damage = 189;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 50000;
			item.rare = 11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 124;
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.mana = 18;
			item.stack = 1;
			item.UseSound = SoundID.Item43;
			item.crit = 37;
			item.shopCustomPrice = 330000;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3069);
			recipe.AddIngredient(ItemID.EmeraldStaff, 2);
			recipe.AddIngredient(mod.ItemType("DreamString"), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}