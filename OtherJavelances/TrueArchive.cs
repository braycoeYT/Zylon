using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class TrueArchive : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Very rarely gives the user the buff 'Archived', increasing damage reduction by 25%\nStacks up to 5\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 69;
			item.ranged = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 2.9f;
			item.value = 35000;
			item.rare = 8;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("TrueArchive");
			item.shootSpeed = 16f;
			item.noMelee = true;
			item.maxStack = 5;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 21 + (item.stack * 10) - 10;
			item.useAnimation = 21 + (item.stack * 10) - 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.redJavelance)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BleedingJavelance"), 45, 3f, player.whoAmI);
			}

			if (Main.rand.NextFloat() < .05f) {
				player.AddBuff(mod.BuffType("Archived"), 60);
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
			recipe.AddIngredient(mod.ItemType("Archive"));
			recipe.AddIngredient(mod.ItemType("AncientMedievalJavelance"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Archive"), 4);
			recipe.AddIngredient(mod.ItemType("AncientMedievalJavelance"), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}