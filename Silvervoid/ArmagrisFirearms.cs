using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Silvervoid
{
	public class ArmagrisFirearms : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Armagris Firearms");
			Tooltip.SetDefault("The pink gun's little brother\nShoots 3 Bullets for the cost of one\n45% chance of not consuming ammo");
		}

		public override void SetDefaults() {
			item.value = 500000;
			item.useStyle = 5;
			item.useAnimation = 8;
			item.useTime = 8;
			item.damage = 41;
			item.width = 60;
			item.height = 45;
			item.knockBack = 1.1f;
			item.shoot = 14;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = 10;
			item.noMelee = true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-3, 0);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(7);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 75f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .45f)
            return false;
			else
			return true;
        }
		
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 11);
			recipe.AddIngredient(ItemID.SDMG);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}