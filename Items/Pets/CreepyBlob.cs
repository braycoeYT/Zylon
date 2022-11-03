using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Pets
{
	public class CreepyBlob : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons the one and only Dirtboi to follow you");
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.ZephyrFish);
			Item.shoot = ProjectileType<Projectiles.Pets.Dirtboi>();
			Item.buffType = BuffType<Buffs.Pets.DirtboiBuff>();
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = -1;
			Item.width = 24;
			Item.height = 24;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			return false;
		}
	}
}