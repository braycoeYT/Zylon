using Microsoft.Xna.Framework;
using System.Drawing.Drawing2D;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class Dirkbow : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 15);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 15;
			Item.useTime = 3;
			Item.damage = 97;
			Item.width = 52;
			Item.height = 58;
			Item.knockBack = 3.25f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ModContent.RarityType<Magenta>();
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-10, 0);
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount % 5 == 4;
        }
        int shootCount = -1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 5 != 0) {
				Vector2 temp = Vector2.Normalize(velocity).RotatedBy(MathHelper.PiOver2);
				Vector2 newPos = position + (temp*Main.rand.NextFloat(-15f, 15f));
				Projectile.NewProjectile(source, newPos - new Vector2(0, 10), velocity, ProjectileType<Projectiles.Bows.DirkbowProj>(), damage, knockback/2f, player.whoAmI);
			}
			return shootCount % 5 == 0;
        }
	}
}