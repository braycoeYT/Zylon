using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class MysticCometStar : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
        }
        public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.White;
		}
        public override bool OnPickup(Player player) {
			player.ManaEffect(20);
			player.statMana += 20;
            return false;
        }
		int Timer;
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            Timer++;
			if (Timer > 1800) Item.active = false;
        }
    }
}