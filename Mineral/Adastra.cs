using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Mineral
{
	public class Adastra : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Adastra");
			Tooltip.SetDefault("To the stars");
		}
		public override void SetDefaults() 
		{
			item.damage = 301;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.3f;
			item.value = 850000;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.StarWrath;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 10;
			item.stack = 1;
			item.UseSound = SoundID.Item12;
			item.rare = 12;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 9f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(mod.ItemType("PhoenixDriver"));
			recipe.AddIngredient(ItemID.FallenStar, 20);
			recipe.AddIngredient(mod.ItemType("DreamString"), 10);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}