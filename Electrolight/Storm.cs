using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Electrolight
{
	public class Storm : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Attacks can electrocute enemies\nJavelance stack penalty is decreased by 10%\nStacks up to 4\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 42;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 2.1f;
			item.value = 20000;
			item.rare = 5;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Storm");
			item.shootSpeed = 18f;
			item.noMelee = true;
			item.maxStack = 4;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 23 + (item.stack * 9) - 9;
			item.useAnimation = 23 + (item.stack * 9) - 9;
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
			recipe.AddIngredient(mod.ItemType("ElectricDesertJavelance"), 2);
			recipe.AddIngredient(mod.ItemType("Electrolight"), 5);
			recipe.AddIngredient(ItemID.SoulofFlight, 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}