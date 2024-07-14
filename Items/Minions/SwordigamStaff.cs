using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class SwordigamStaff : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 71;
			Item.knockBack = 5f;
			Item.mana = 20;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 15, 0, 0);
			Item.rare = RarityType<Magenta>();
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = BuffType<Buffs.Minions.Swordigam>();
			Item.shoot = ProjectileType<Projectiles.Minions.Swordigam>();
		}
        public override bool CanUseItem(Player player) {
            return player.maxMinions-player.slotsMinions >= 2f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			Projectile.NewProjectile(source, Main.MouseWorld, velocity, type, damage, knockback, Main.myPlayer);
			return false;
		}
	}
}