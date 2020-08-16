using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mushroom
{
	public class BookofShrooms : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Book of Shrooms");
		}

		public override void SetDefaults() 
		{
			item.value = 50000;
			item.useStyle = 5;
			item.useAnimation = 19;
			item.useTime = 19;
			item.damage = 10;
			item.width = 12;
			item.height = 24;
			item.knockBack = 4.1f;
			item.shoot = mod.ProjectileType("MushroomBolt");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 1;
			item.mana = 3;
			item.UseSound = SoundID.Item43;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.Mushroom, 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}