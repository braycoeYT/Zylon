using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class LeecherJavelance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Its only dream is to leech life one day, which it is currently incapable of.\nStacks up to 3\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 52;
			item.height = 52;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 3.8f;
			item.value = 7500;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("LeecherJavelance");
			item.shootSpeed = 11f;
			item.noMelee = true;
			item.maxStack = 3;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.consumable = false;
		}
		public override void UpdateInventory(Player player)
		{
			item.useTime = 28 + (item.stack * 10) - 10;
			item.useAnimation = 28 + (item.stack * 10) - 10;
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
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}