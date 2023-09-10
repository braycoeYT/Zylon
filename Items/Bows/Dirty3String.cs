using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class Dirty3String : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dirty 3-String");
			// Tooltip.SetDefault("Has a low firerate, but fires 1-3 arrows");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.damage = 13;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 1.3f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Gray;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            float numberProjectiles = Main.rand.Next(1, 4);
			float rotation = MathHelper.ToRadians(4);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return numberProjectiles == 1;
        }
	}
}