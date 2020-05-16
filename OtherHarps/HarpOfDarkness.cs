using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherHarps
{
	public class HarpOfDarkness : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Harp of Darkness");
			Tooltip.SetDefault("'It's calling...'\nLeft Click to only shoot normal notes\nRight Click to shoto poison, dungeonist, fire, and normal notes");
		}

		public override void SetDefaults() 
		{
			item.damage = 28;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 55500;
			item.rare = 3;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 1;
			item.shootSpeed = 8.5f;
			item.noMelee = true;
			item.mana = 7;
			item.holdStyle = 3;
			item.stack = 1;
			item.UseSound = SoundID.Item26;
		}
		
		public override bool AltFunctionUse(Player player)
        {
            return true;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
            {
				int ran = Main.rand.Next(1, 5);
				if (ran == 1) type = 76;
				if (ran == 2) type = mod.ProjectileType("PoisonSound");
				if (ran == 3) type = mod.ProjectileType("DungeonNote");
				if (ran == 4) type = mod.ProjectileType("FireNote");
			}
			else
			{
				type = 76;
			}
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShadowHarp"));
			recipe.AddIngredient(mod.ItemType("HarpOfTheBonechiller"));
			recipe.AddIngredient(mod.ItemType("VinewireHarp"));
			recipe.AddIngredient(mod.ItemType("MagmusHarp"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BloodRedHarp"));
			recipe.AddIngredient(mod.ItemType("HarpOfTheBonechiller"));
			recipe.AddIngredient(mod.ItemType("VinewireHarp"));
			recipe.AddIngredient(mod.ItemType("MagmusHarp"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}