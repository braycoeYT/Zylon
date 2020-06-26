using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class AncientDiscusHarp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sandgrain Zapharp");
			Tooltip.SetDefault("10% chance of shooting an electric bolt");
		}

		public override void SetDefaults() 
		{
			item.damage = 13;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 25000;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 76;
			item.shootSpeed = 8.5f;
			item.noMelee = true;
			item.mana = 4;
			item.holdStyle = 3;
			item.stack = 1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ran = Main.rand.Next(1, 11);
			if (ran == 1) type = 440;
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}