using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class ArcticVixen : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 7, 25);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 6;
			Item.useTime = 6;
			Item.damage = 92;
			Item.width = 50;
			Item.height = 36;
			Item.knockBack = 6.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			//Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.LightRed;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount % 7 == 0;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int shootCount = -1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = 0;
			shootCount++;
			if (shootCount % 21 > 13) {
				SoundEngine.PlaySound(SoundID.Item11, player.Center);
				Projectile.NewProjectile(source, position, velocity, ProjectileID.SnowBallFriendly, (int)(damage*0.2f), knockback/4f, Main.myPlayer);
				if (shootCount % 21 == 19) Item.reuseDelay = 36;
				return false;
			}
			if (shootCount % 7 == 0) SoundEngine.PlaySound(SoundID.Item41, player.Center);
			return shootCount % 7 == 0;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Foxtrot>());
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 8);
			recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}