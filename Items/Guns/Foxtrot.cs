using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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
			Item.useAnimation = 48;
			Item.useTime = 8;
			Item.damage = 45;
			Item.width = 42;
			Item.height = 30;
			Item.knockBack = 6f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			//Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Green;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount % 6 == 0;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int shootCount = -1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = 0;
			shootCount++;
			if (shootCount % 18 > 11) {
				SoundEngine.PlaySound(SoundID.Item11, player.Center);
				Projectile.NewProjectile(source, position, velocity*0.9f, type, (int)(damage*0.13f), knockback/4f, Main.myPlayer);
				if (shootCount % 18 == 17) Item.reuseDelay = 40;
				return false;
			}
			if (shootCount % 6 == 0) SoundEngine.PlaySound(SoundID.Item41, player.Center);
			return shootCount % 6 == 0;
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