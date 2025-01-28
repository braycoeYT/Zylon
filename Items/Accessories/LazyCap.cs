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
			Item.value = Item.sellPrice(0, 1, 21);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.velocity.Length() < 0.01f) player.GetAttackSpeed(DamageClass.Generic) += 0.2f;
		}
	}
}