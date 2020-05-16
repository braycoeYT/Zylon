using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class BloodyCyst : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Cyst");
			Tooltip.SetDefault("'It's calling...'\nLeft click to shoot red vines\nRight click to shoot a vampire knife\nVampire knives cost double the amount of mana and do less damage");
		}

		public override void SetDefaults() 
		{
			item.damage = 41;
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
			item.shoot = 150;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.mana = 11;
			item.holdStyle = 3;
			item.stack = 1;
			item.UseSound = SoundID.Item2;
		}
		
		public override bool AltFunctionUse(Player player)
        {
            return true;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
            {
				item.damage = 32;
				item.mana = 22;
				type = 304;
			}
			else
			{
				type = 150;
				item.damage = 41;
				item.mana = 11;
			}
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatmakerHarp"));
			recipe.AddIngredient(mod.ItemType("PlainNoodle"), 3);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.Ichor, 4);
			recipe.AddIngredient(ItemID.Vertebrae, 6);
			recipe.AddTile(218);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}