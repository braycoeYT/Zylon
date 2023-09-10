using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Stalactite : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("At full health, shoots a sword beam");
		}
		public override void SetDefaults() {
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.6f;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MarbleGhostSword>();
			Item.shootSpeed = 11f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            return player.statLife == player.statLifeMax2;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBroadsword);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.MarbleBlock, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumBroadsword);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.MarbleBlock, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}