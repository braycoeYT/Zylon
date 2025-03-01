using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class AssassinsGreatbow : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.buyPrice(1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 10;
			Item.useTime = 2;
			Item.damage = 86;
			Item.width = 36;
			Item.height = 66;
			Item.knockBack = 5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 22f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ModContent.RarityType<PurpleModded>();
			Item.reuseDelay = 40;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextBool(5);
        }
        int shootCount = -1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 5 == 1 || shootCount % 5 == 2) {
				Vector2 dist = Vector2.Normalize(velocity.RotatedBy(MathHelper.PiOver2));
				Projectile.NewProjectile(source, position + dist*24*(shootCount%5), velocity, type, damage, knockback, Main.myPlayer);
				Projectile.NewProjectile(source, position - dist*24*(shootCount%5), velocity, type, damage, knockback, Main.myPlayer);
			}
			else return true;
			return false;
        }
	}
}