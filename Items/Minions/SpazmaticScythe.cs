using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Minions
{
	public class SpazmaticScythe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons five spazscythes to rotate around you\nSpazscythes do not take up any minion slots\nSpazscythes dissipate after 5 hits\nSpazscythes cannot be resummoned until all of them are dissipated");
		}
		public override void SetDefaults() {
			Item.damage = 63;
			Item.knockBack = 8f;
			Item.mana = 60;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.shoot = ProjectileType<Projectiles.Minions.Spazsickle>();
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			position = Main.MouseWorld;
			for (int i = 0; i < 5; i++)
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, i);
			return false;
		}
	}
}