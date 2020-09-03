using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherJavelances
{
	public class Archive : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Very rarely gives the user the buff 'Archived', increasing damage reduction by 25%\nStacks up to 4\nMore javelances means more javelances thrown\nUse time is decreased with more javelances");
		}

		public override void SetDefaults() 
		{
			item.damage = 52;
			item.ranged = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2.1f;
			item.value = 20000;
			item.rare = ItemRarityID.Pink;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Archive");
			item.shootSpeed = 15f;
			item.noMelee = true;
			item.maxStack = 4;
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

			if (Main.rand.NextFloat() < .03f) {
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
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 9);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}