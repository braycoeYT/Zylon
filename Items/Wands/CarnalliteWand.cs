using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class CarnalliteWand : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Rains leaves from the sky at the cursor");
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 23;
			Item.width = 28;
			Item.height = 30;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Leaf>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 5;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, player.position.Y - 400), new Vector2(Main.rand.NextFloat(-1.5f, 1.5f), 14), ModContent.ProjectileType<Projectiles.Leaf>(), damage, knockback, player.whoAmI, 2f);
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