using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class JungleJavelance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("May poison enemies\nStacks up to 3\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 1;
			item.knockBack = 5.9f;
			item.value = 220000;
			item.rare = 2;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("JungleJavelance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			item.useTime = 27 + (item.stack * 3);
			item.useAnimation = 27 + (item.stack * 3);
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
			recipe.AddIngredient(ItemID.JungleSpores, 14);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}