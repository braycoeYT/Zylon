using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class WyvernsCall : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Wyvern's Call");
			// Tooltip.SetDefault("Converts arrows to powerful wyvern bolts");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.damage = 48;
			Item.width = 20;
			Item.height = 52;
			Item.knockBack = 3.25f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 26f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item96;
			Item.rare = ItemRarityID.LightRed;
		}
        int shootCount;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            shootCount++;
			if (shootCount % 2 == 1) type = ProjectileType<Projectiles.Bows.WyvernGreenBolt>();
			else type = ProjectileType<Projectiles.Bows.WyvernRedBolt>();
        }
	}
}