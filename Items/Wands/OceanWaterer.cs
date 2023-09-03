using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class OceanWaterer : ModItem
	{
        public override void SetStaticDefaults() {
            // Tooltip.SetDefault("'Seems a little much for just winning a water gun fight...'\nWaterboards enemies with a barrage of water splashes");
        }
        public override void SetDefaults() {
			Item.damage = 61;
			Item.DamageType = DamageClass.Magic;
			Item.width = 74;
			Item.height = 18;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.4f;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ProjectileID.WaterStream;
			Item.shootSpeed = 22f;
			Item.mana = 10;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            for (int i = 0; i < 2; i++)
				Projectile.NewProjectile(source, player.Center, velocity * new Vector2(Main.rand.NextFloat(0.8f, 1.2f), Main.rand.NextFloat(0.8f, 1.2f)).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-10, 10))), type, damage, knockback, Main.myPlayer);
			return true;
        }
	}
}