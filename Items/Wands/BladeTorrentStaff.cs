using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class BladeTorrentStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 100;
			Item.width = 58;
			Item.height = 58;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.75f;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.BladeTorrentProj>();
			Item.shootSpeed = 24f;
			Item.noMelee = true;
			Item.mana = 8;
			Item.stack = 1;
			Item.UseSound = SoundID.Item72;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for (int i = 0; i < 3; i++) {
				Vector2 newCenter = Main.MouseWorld - new Vector2(0, 600).RotatedByRandom(MathHelper.TwoPi);
				Vector2 newVel = Vector2.Normalize(Main.MouseWorld - newCenter)*velocity.Length();
				float timeLeft = 600/velocity.Length();
				Projectile.NewProjectile(source, newCenter, newVel, type, damage, knockback, Main.myPlayer, timeLeft);
			}
			return false;
        }
    }
}