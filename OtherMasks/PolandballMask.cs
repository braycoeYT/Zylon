using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherMasks
{
	[AutoloadEquip(EquipType.Head)]
	public class PolandballMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Can Polandball into space?");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 500000;
			item.rare = 4;
			item.vanity = true;
		}
	}
}