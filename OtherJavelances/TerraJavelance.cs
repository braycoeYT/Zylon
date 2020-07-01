using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class TerraJavelance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Javelances can bombard terra orbs, steal life, and very rarely gives the user the buff 'Archived', increasing damage reduction by 25%\nStacks up to 6\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 91;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 2.9f;
			item.value = 500000;
			item.rare = 8;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("TerraJavelance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 6;
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

			if (Main.rand.NextFloat() < .035f) {
				player.AddBuff(mod.BuffType("Archived"), 60);
			}
			
			item.useTime = 30 + (item.stack * 3);
			item.useAnimation = 30 + (item.stack * 3);
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
			recipe.AddIngredient(mod.ItemType("TrueShadowdance"));
			recipe.AddIngredient(mod.ItemType("TrueArchive"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TrueFleshleech"));
			recipe.AddIngredient(mod.ItemType("TrueArchive"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TrueShadowdance"), 5);
			recipe.AddIngredient(mod.ItemType("TrueArchive"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 6);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TrueFleshleech"), 5);
			recipe.AddIngredient(mod.ItemType("TrueArchive"), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 6);
			recipe.AddRecipe();
		}
	}
}