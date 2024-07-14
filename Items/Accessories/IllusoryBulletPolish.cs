using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;

namespace Zylon.Items.Accessories
{
	public class IllusoryBulletPolish : ModItem
	{
		public override void SetDefaults() {
			Item.width = 44;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.LightRed;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.illusoryBulletPolish = true;
		}
    }
}