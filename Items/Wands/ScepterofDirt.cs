using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class ScepterofDirt : ModItem
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Scepter of Dirt");
			// Tooltip.SetDefault("Rains dirt balls from above on enemies");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 13;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 58;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.DirtBallScepter>();
			Item.shootSpeed = 8f;
			Item.mana = 5;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, player.Center.Y - 500), new Vector2(Main.rand.NextFloat(-0.5f, 0.5f), Item.shootSpeed), type, damage, knockback, Main.myPlayer);
			return false;
        }
    }
}