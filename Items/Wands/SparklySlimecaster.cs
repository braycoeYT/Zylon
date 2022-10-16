using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class SparklySlimecaster : ModItem
	{
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains a giant sparkly gel from above that explodes into bouncy smaller ones on impact");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 41;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.8f;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.SparklySlimecasterProj>();
			Item.shootSpeed = 25f;
			Item.mana = 12;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, player.Center.Y - 400), new Vector2(0, Item.shootSpeed), type, damage, knockback, Main.myPlayer);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SparklySlimecaster>());
			recipe.AddIngredient(ItemID.GelBalloon, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}