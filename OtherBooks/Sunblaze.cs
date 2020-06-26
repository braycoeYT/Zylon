using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherBooks
{
	public class Sunblaze : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sunblaze");
			Tooltip.SetDefault("Shoots five flames at the cursor");
		}

		public override void SetDefaults() 
		{
			item.value = 580000;
			item.useStyle = 5;
			item.useAnimation = 29;
			item.useTime = 29;
			item.damage = 109;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.9f;
			item.shoot = 85;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = 10;
			item.mana = 11;
			item.UseSound = SoundID.Item116;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 5;
			float rotation = MathHelper.ToRadians(5) * 6.5f;
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 6.5f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}