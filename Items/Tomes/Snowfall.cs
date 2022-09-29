using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Snowfall : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains snowflakes from above towards your cursor");
		}
		public override void SetDefaults() {
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 0, 38);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.SnowfallProj>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 10;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        	for (int i = 0; i < 3; i++) {
				Vector2 spawn = new Vector2(Main.MouseWorld.X + Main.rand.Next(-160, 161), player.position.Y - 400);
				Vector2 target = spawn - Main.MouseWorld;
				target.Normalize();
				Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target*-12f, type, damage, knockback, Main.myPlayer);
			}
			return false;
		}
	}
}