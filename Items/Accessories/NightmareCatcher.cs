using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class NightmareCatcher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'You can feel the bad vibes being emitted from this'\nStriking enemies has a chance to release lost nightmares, which can be absorbed by players to recover health\nTrue melee attacks have a much higher chance to release lost nightmares");
		}
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 52;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.nightmareCatcher = true;
        }
	}
}