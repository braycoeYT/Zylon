using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class EldritchTentacles : ModItem
	{
		public override void SetStaticDefaults() {
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(90, 6.5f, 1.2f);
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 6, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.wingTimeMax = 90;
			p.jellyExpert = true;
			if (player.wet) {
				if (player.accRunSpeed > 0) player.accRunSpeed += 1.25f;
				player.jumpSpeedBoost += 1.5f;
				player.moveSpeed += 0.2f;
            }
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.75f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.125f;
			if (player.wet) {
				ascentWhenFalling = 1.5f;
				ascentWhenRising = 0.3f;
				maxCanAscendMultiplier = 1.5f;
				maxAscentMultiplier = 2f;
				constantAscend = 0.2f;
            }
		}
	}
}