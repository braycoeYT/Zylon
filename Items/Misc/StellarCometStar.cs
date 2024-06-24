using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class StellarCometStar : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
        }
        public override void SetDefaults() {
			Item.width = 34;
			Item.height = 34;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 35);
			Item.rare = ItemRarityID.White;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.PurpleTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override bool OnPickup(Player player) {
			player.ManaEffect(10);
			player.statMana += 10;
            return false;
        }
		int Timer;
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            Timer++;
			if (Timer > 900) Item.active = false;
        }
    }
}