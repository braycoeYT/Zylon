using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	public class Zapfire : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zapfire");
			Tooltip.SetDefault("Shoots an electro barrage every twelve shots");
		}

		public override void SetDefaults() 
		{
			item.value = 25000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 21;
			item.useTime = 21;
			item.damage = 11;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.5f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.rare = ItemRarityID.Blue;
		}
		int projCount;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			projCount += 1;
			if (projCount % 12 == 0)
			{
				float numberProjectiles = Main.rand.Next(9, 16);
				float rotation = MathHelper.ToRadians(Main.rand.Next(3, 11));
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 1f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 2.5f, perturbedSpeed.Y * 2.5f, ProjectileID.LaserMachinegunLaser, damage, knockBack, player.whoAmI);
				}
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}