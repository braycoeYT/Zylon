using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class Fleshleech : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Slowly leeches life\nStacks up to 4\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 31;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 1;
			item.knockBack = 3.8f;
			item.value = 350000;
			item.rare = 4;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Fleshleech");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 4;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.redJavelance)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			}

			item.useTime = 42 + (item.stack * 3);
			item.useAnimation = 42 + (item.stack * 3);
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(10);
			if (numberProjectiles > 1)
			{
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .9f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
			return false;
			}
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LeecherJavelance"));
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"));
			recipe.AddIngredient(mod.ItemType("JungleJavelance"));
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LeecherJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("JungleJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"), 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}