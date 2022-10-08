using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class CarnalliteCutlass : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Every fourth swing shoots a pile of leaves");
		}

		public override void SetDefaults() {
			Item.damage = 29;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Leaf>();
			Item.shootSpeed = 7f;
		}
		int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			int numberProjectiles = 5 + Main.rand.Next(2);
			if (shootCount % 4 == 0) {
				SoundEngine.PlaySound(SoundID.Item69, position);
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.8f, 1.2f), velocity.Y * Main.rand.NextFloat(0.8f, 1.2f)).RotatedByRandom(MathHelper.ToRadians(14));
					Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage * 0.5f), knockback * 0.5f, player.whoAmI);
				}
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}