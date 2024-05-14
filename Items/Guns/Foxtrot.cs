using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class Foxtrot : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 4, 45);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 37;
			Item.useTime = 37;
			Item.damage = 43;
			Item.width = 42;
			Item.height = 30;
			Item.knockBack = 6f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Green;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount % 9 < 3;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 9 == 0) {
				Item.damage = 43;
				Item.UseSound = SoundID.Item41;
			}
			if (shootCount % 9 == 1) {
				Item.knockBack = 1.25f;
				Item.shootSpeed = 8f;
			}
			if (shootCount % 9 == 2) {
				Item.damage = 9;
				Item.useAnimation = 9;
				Item.useTime = 9;
				Item.UseSound = SoundID.Item11;
			}
			if (shootCount % 9 == 8) {
				Item.knockBack = 6f;
				Item.useAnimation = 37;
				Item.useTime = 37;
				Item.shootSpeed = 10f;
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DynastyWood, 18);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}