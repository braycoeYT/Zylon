using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class ForgottenRosesSaber : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Forgotten Rose's Saber");
			Tooltip.SetDefault("Shoots a seed and several circling leaves with each swing\nEvery third swing's seed is replaced with a blossomed rose\nBlossomed roses release several spore clouds");
		}
		public override void SetDefaults() {
			Item.damage = 96;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.2f;
			Item.value = Item.sellPrice(0, 16, 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MiniRose>();
			Item.shootSpeed = 12f;
		}
		int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			int projType;
			if (shootCount % 3 == 0) projType = ModContent.ProjectileType<Projectiles.Swords.MegaRose>();
			else projType = ProjectileID.SeedlerNut;
			Projectile.NewProjectile(source, position, velocity, projType, damage, knockback, Main.myPlayer);
			SoundEngine.PlaySound(SoundID.Item69, position);
			for (int i = 0; i < 2; i++) {
				Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.8f, 1.2f), velocity.Y * Main.rand.NextFloat(0.8f, 1.2f)).RotatedByRandom(MathHelper.ToRadians(14));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage * 0.5f), knockback * 0.5f, player.whoAmI, -3f);
			}
			for (int i = 0; i < 2; i++) {
				Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.8f, 1.2f), velocity.Y * Main.rand.NextFloat(0.8f, 1.2f)).RotatedByRandom(MathHelper.ToRadians(14));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage * 0.5f), knockback * 0.5f, player.whoAmI, 3f);
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CarnalliteCutlass>());
			recipe.AddIngredient(ItemID.ChlorophyteClaymore);
			recipe.AddIngredient(ItemID.ChlorophyteSaber);
			recipe.AddIngredient(ItemID.Seedler);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}