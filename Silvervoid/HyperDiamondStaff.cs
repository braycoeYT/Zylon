using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Silvervoid
{
	public class HyperDiamondStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Quickly rain diamond bolts");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 241;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 250000;
			item.rare = 10;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 126;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 6;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
			item.crit = 3;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.Next(-2, 2);
			speedY = 31;
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreStaff);
			recipe.AddIngredient(mod.ItemType("DreamString"), 13);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 6);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}