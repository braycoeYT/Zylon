using Zylon.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Wings)]
	public class GemstoneWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is as heavy as 25 Ubercabachons!\nWingtime: 250\nHorizontal speed: 10\nHorizontal acceleration: 2.75");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 250000;
			item.rare = 11;
			item.accessory = true;
			item.expert = true;
			item.defense = 10;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 250;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.8f;
			ascentWhenRising = 0.3f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.145f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 10f;
			acceleration *= 2.75f;
		}
	}
}