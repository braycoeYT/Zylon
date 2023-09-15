using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class SunsGlare : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1, 60);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 37;
			Item.useTime = 37;
			Item.damage = 33;
			Item.width = 44;
			Item.height = 72;
			Item.knockBack = 2.5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item109;
			Item.rare = ItemRarityID.Green;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int a = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
			Projectile.NewProjectile(source, position, Vector2.Zero, ProjectileType<Projectiles.Bows.SunsGlareProj>(), 1, 0f, Main.myPlayer, a);
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}