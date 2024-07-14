using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class LazyCap : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 89);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.velocity.Length() < 0.01f) player.GetCritChance(DamageClass.Generic) += 12;
		}
	}
}