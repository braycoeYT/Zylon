using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class Shadowdance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Each Javelance rains shadowdance orbs\nStacks up to 4\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 52;
			item.height = 52;
			item.useTime = 39;
			item.useAnimation = 39;
			item.useStyle = 1;
			item.knockBack = 3.8f;
			item.value = 15000;
			item.rare = 4;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Shadowdance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 4;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 39 + (item.stack * 10) - 10;
			item.useAnimation = 39 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.redJavelance)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			}
			float numberProjectiles = item.stack;
			float rotation = MathHelper.ToRadians(18);
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
			recipe.AddIngredient(mod.ItemType("RoyalCorruptJavelance"));
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"));
			recipe.AddIngredient(mod.ItemType("VinepowerJavelance"));
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RoyalCorruptJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("AquaticJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("VinepowerJavelance"), 3);
			recipe.AddIngredient(mod.ItemType("FirebentJavelance"), 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}