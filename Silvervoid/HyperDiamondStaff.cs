using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Silvervoid
{
	public class HyperDiamondStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Concentrate shards of light from the mirror on the end'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 92;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 505000;
			item.rare = 10;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 126;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
			item.crit = -2;
			item.shopCustomPrice = 330000;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DiamondStaff);
			recipe.AddIngredient(mod.ItemType("DreamString"), 13);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LastPrism);
			recipe.AddIngredient(mod.ItemType("DreamString"), 13);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}