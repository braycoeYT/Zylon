using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class Codebreaker : ModItem
	{
        public override void SetDefaults() {
			Item.width = 42;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 8);
			Item.rare = ItemRarityID.Pink;
			Item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.moveSpeed += 0.15f;
			player.wingTimeMax += 30;
			p.codebreaker = true;
		}
	}
}