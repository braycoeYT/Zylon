using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Asteri
{
	public class DrakonsGrasp : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Drakon's Grasp");
			Tooltip.SetDefault("Mod Crossover Item: Asteri Mod\nIs that a drakon's claws? Or its jaw?\nHitting enemies will launch a ghost projectile in the oppisite direction for half damage\nAttacks can venom enemies\nStacks up to 6\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 93;
			item.ranged = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.5f;
			item.value = 32500;
			item.rare = ItemRarityID.Red;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("DrakonsGrasp");
			item.shootSpeed = 20f;
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
			
			item.useTime = 26 + (item.stack * 10) - 10;
			item.useAnimation = 26 + (item.stack * 10) - 10;
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
			Mod asteri = ModLoader.GetMod("Asteri");
			if (asteri != null)
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(asteri.ItemType("DrakonScale"), 45);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this, 6);
				recipe.AddRecipe();
			}
		}
	}
}