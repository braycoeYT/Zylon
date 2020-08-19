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
			Tooltip.SetDefault("Rains pink stars");
		}

		public override void SetDefaults() 
		{
			item.value = 550000;
			item.useStyle = 5;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 211;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = ProjectileID.StarWrath;
			item.shootSpeed = 27f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 11;
			item.mana = 7;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.NextFloat(-1, 2);
			speedY = 19;
			return true;
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