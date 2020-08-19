using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class TrueShadowdance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Each Javelance spams shadowdance orbs\nStacks up to 5\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 80;
			item.ranged = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = 1;
			item.knockBack = 4f;
			item.value = 35000;
			item.rare = 8;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("TrueShadowdance");
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.maxStack = 5;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 41 + (item.stack * 10) - 10;
			item.useAnimation = 41 + (item.stack * 10) - 10;
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
			recipe.AddIngredient(mod.ItemType("Shadowdance"));
			recipe.AddIngredient(mod.ItemType("AncientMedievalJavelance"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Shadowdance"), 4);
			recipe.AddIngredient(mod.ItemType("AncientMedievalJavelance"), 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}