using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class DirtballMask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 0, 75, 0);
			Item.rare = ItemRarityID.Blue;
			Item.vanity = true;
		}
	}
}