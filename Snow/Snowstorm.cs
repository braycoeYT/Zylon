using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Snow
{
	public class Snowstorm : ModItem
	{
		public override void SetDefaults() 
		{
			item.value = 20000;
			item.useStyle = 5;
			item.useAnimation = 21;
			item.useTime = 21;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.5f;
			item.shoot = 1;
			item.shootSpeed = 44f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 6);
			recipe.AddIngredient(ItemID.IceBlock, 11);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}