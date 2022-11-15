using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class MagnificentOrb : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magnificent Orb");
			Tooltip.SetDefault("'Warning: May cause spatial anomalies.'");
		}
		public override void SetDefaults() {
			Item.damage = 23;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.MagnificentOrbPortal>();
			Item.shootSpeed = 20f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
			Item.noUseGraphic = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {

			Projectile.NewProjectile(source, position + (velocity * 4.5f), velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-1, 1))), type, damage, knockback, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}