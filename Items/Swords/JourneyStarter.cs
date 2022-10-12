using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class JourneyStarter : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'Only the start of the endless road to infinity'\nAlternates between firing different types of bolts");
        }
        public override void SetDefaults() {
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 32;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.8f;
			Item.value = Item.sellPrice(0, 1, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.JourneyStarterBolt>();
			Item.shootSpeed = 11f;
		}
        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.1f, 0.2f, 0.75f);
        }
		int shootCount = -1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, shootCount);
			return false;
        }
    }
}