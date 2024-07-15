using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Pets
{
	public class AncientGameController : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToVanitypet(ProjectileType<Projectiles.Pets.Gamerblade>(), BuffType<Buffs.Pets.Gamerblade>());
			Item.width = 42;
			Item.height = 28;
			Item.rare = ItemRarityID.Master;
			Item.master = true;
			Item.value = Item.sellPrice(0, 15);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			return false;
		}
	}
}