using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Zenith
{
	public class HighNoon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("High Noon");
			Tooltip.SetDefault("Shoots three flames at the cursor and seven elemental bolts in random directions");
		}

		public override void SetDefaults() 
		{
			item.value = 1000000;
			item.useStyle = 5;
			item.useAnimation = 21;
			item.useTime = 21;
			item.damage = 160; //205
			item.width = 12;
			item.height = 24;
			item.knockBack = 4.2f;
			item.shoot = 85;
			item.shootSpeed = 13f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 10;
			item.mana = 9;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5) * 5f;
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(player.Center, new Vector2(0, 2).RotatedByRandom(MathHelper.TwoPi), 121, (int)(damage / 4f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 3).RotatedByRandom(MathHelper.TwoPi), 122, (int)(damage / 3.8f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), 123, (int)(damage / 3.6f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 5).RotatedByRandom(MathHelper.TwoPi), 118, (int)(damage / 3.4f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 6).RotatedByRandom(MathHelper.TwoPi), 124, (int)(damage / 3.2f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 7).RotatedByRandom(MathHelper.TwoPi), 125, (int)(damage / 3f), knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), 126, (int)(damage / 2.8f), knockBack, Main.myPlayer);
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NebulaBlaze);
			recipe.AddIngredient(ItemID.NebulaArcanum);
			recipe.AddIngredient(mod.ItemType("Sunblaze"));
			recipe.AddIngredient(ItemID.BubbleGun);
			recipe.AddIngredient(ItemID.VenomStaff);
			recipe.AddIngredient(ItemID.CrystalSerpent);
			recipe.AddIngredient(ItemID.DemonScythe);
			recipe.AddIngredient(ItemID.WaterBolt);
			recipe.AddIngredient(ItemID.WandofSparking);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}