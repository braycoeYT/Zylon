using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Books
{
	public class Fleshclump : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Tosses several flesh clumps towards the cursor");
		}
		public override void SetDefaults() {
			item.value = 150000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 36;
			item.useTime = 36;
			item.damage = 42;
			item.width = 12;
			item.height = 24;
			item.knockBack = 3.7f;
			item.shoot = mod.ProjectileType("FleshClump");
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.LightRed;
			item.mana = 23;
			item.UseSound = SoundID.Item116;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 4 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX + Main.rand.NextFloat(-1, 2), speedY + Main.rand.NextFloat(-1, 2)).RotatedByRandom(MathHelper.ToRadians(10));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
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