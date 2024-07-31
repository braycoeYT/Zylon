using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class SnakeEye : ModItem
	{
		public override void SetDefaults() {
			Item.width = 50;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Yellow;
			Item.maxStack = 2;
		}
        public override void UpdateInventory(Player player) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.snakeEye) p.damageVariation += 1.333333f*Item.stack;
			p.snakeEye = true;
        }
    }
}