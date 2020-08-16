using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class CrystalathanWonder : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Crystalathan Wonder");
			Tooltip.SetDefault("Rain pink stars at an extreme speed");
		}

		public override void SetDefaults() 
		{
			item.value = 120000;
			item.useStyle = 5;
			item.useAnimation = 3;
			item.useTime = 3;
			item.damage = 179;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = 9;
			item.shootSpeed = 27f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 11;
			item.mana = 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}