using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Magentite
{
	public class MagentiteMagnet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magentite Magnet");
			Tooltip.SetDefault("Stacks up to 3\nEach javelance can launch pink bolts towards the mouse position\nBolt speed is based on the javelance's vertical speed\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 13;
			item.ranged = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = 1 ;
			item.knockBack = 5.1f;
			item.value = 50000;
			item.rare = 0;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("MagentaMagnet");
			item.shootSpeed = 10.5f;
			item.noMelee = true;
			item.maxStack = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 31 + (item.stack * 10) - 10;
			item.useAnimation = 31 + (item.stack * 10) - 10;
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
			recipe.AddIngredient(mod.ItemType("MagentiteJavelance"), 2);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 6);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}