using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class LoadedDie : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 24;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
		}
        public override void UpdateInventory(Player player) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.loadedDie) p.damageVariation += 1f;
			p.loadedDie = true;
        }
    }
}