using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mushroom
{
	public class Mushbow : ModItem
	{
		public override void SetDefaults() 
		{
			item.value = 50000;
			item.useStyle = 5;
			item.useAnimation = 24;
			item.useTime = 24;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0;
			item.shoot = 1;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenBow);
			recipe.AddIngredient(ItemID.Mushroom, 14);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}