using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Pets
{
	public class DS_91Controller : ModItem
	{
		public override void SetStaticDefaults() { //finish
			// DisplayName.SetDefault("DS-91 Controller");
			// Tooltip.SetDefault("Summons a forgetten and malfunctioning model of drone servant to follow you");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DefaultToVanitypet(ProjectileType<Projectiles.Pets.DS_91Pet>(), BuffType<Buffs.Pets.DS_91Pet>());
			Item.width = 28;
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