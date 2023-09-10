using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class Slimecaster : ModItem
	{
        public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Rains a slime mass from above that explodes into slime spikes upon contact");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 13;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.6f;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.SlimecasterProj>();
			Item.shootSpeed = 25f;
			Item.mana = 9;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, player.Center.Y - 400), new Vector2(0, Item.shootSpeed), type, damage, knockback, Main.myPlayer);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 5);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}