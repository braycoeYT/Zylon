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
			Tooltip.SetDefault("'The forgotten rose's bloom will be others' doom!'\nSwings release a blossomed rose\nBlossomed roses release spore clouds after stopping\nEvery third swing also releases a ring of roses");
		}
		public override void SetDefaults() {
			Item.damage = 65;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.2f;
			Item.value = Item.sellPrice(0, 16, 50);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MegaRose>();
			Item.shootSpeed = 12f;
		}
		int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			int jimbo;
			if (shootCount % 3 == 0) jimbo = 1;
			else jimbo = 0;
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage*0.75f), knockback, Main.myPlayer, jimbo);
			SoundEngine.PlaySound(SoundID.Item69, position);
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CarnalliteCutlass>());
			recipe.AddIngredient(ItemID.ChlorophyteSaber);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}