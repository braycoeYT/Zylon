using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Pets
{
	public class DiskDrive : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToVanitypet(ProjectileType<Projectiles.Pets.Diskling>(), BuffType<Buffs.Pets.Diskling>());
			Item.width = 40;
			Item.height = 20;
			Item.rare = ItemRarityID.Master;
			Item.master = true;
			Item.value = Item.sellPrice(0, 5);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			return false;
		}
	}
} 