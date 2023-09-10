using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class SpareLeg : ModItem
	{
        public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Summons a big bone from above that unleashes a torrent of bones");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 65;
			Item.useAnimation = 65;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.6f;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.BigBone>();
			Item.shootSpeed = 13f;
			Item.mana = 21;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, player.Center.Y - 400), new Vector2(0, 20), type, damage, knockback, Main.myPlayer);
			return false;
        }
    }
}