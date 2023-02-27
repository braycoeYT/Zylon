using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class GoblinArchbow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires four arrows in quick succession, only consuming one ammo");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1, 75);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 5;
			Item.damage = 5;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 0.1f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 6.9f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			//Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Blue;
			Item.reuseDelay = 40;
			Item.consumeAmmoOnLastShotOnly = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            SoundEngine.PlaySound(SoundID.Item5, player.Center);
			return true;
        }
    }
}