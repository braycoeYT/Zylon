using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Pets
{
	public class EldritchGland : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It's covered in a thin coat of some sticky substance, but looks useless.'\nSummons a spooky jellyfish to follow you");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DefaultToVanitypet(ProjectileType<Projectiles.Pets.SpookyJellyfish>(), BuffType<Buffs.Pets.SpookyJellyfish>());
			Item.width = 38;
			Item.height = 50;
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