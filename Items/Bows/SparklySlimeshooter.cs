using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class SparklySlimeshooter : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Turns regular arrows into sparkly arrows that release bouncy sparkly gel on impact");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 60);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.damage = 45;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 10.5f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Pink;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (type == ProjectileID.WoodenArrowFriendly) type = ProjectileType<Projectiles.Bows.SparklyArrow>();
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Slimeshooter>());
			recipe.AddIngredient(ItemID.GelBalloon, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}