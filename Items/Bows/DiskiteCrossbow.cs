using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class DiskiteCrossbow : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Every third shot is supercharged, causing it to be shot with much higher damage and knockback");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 25);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.damage = 17;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 4.1f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Blue;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 3 == 0) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, velocity * 1.5f, type, (int)(damage * 1.5f), knockback * 1.5f, Main.myPlayer);
				return false;
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}