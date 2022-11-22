using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class LostNightmare : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'You shouldn't be able to read this unless you're cheating, or something has gone terribly wrong!\nIn that case, hello.\nHope you like the mod.'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(69, 69, 4, 20);
			Item.rare = ItemRarityID.LightPurple;
		}
		int Timer;
		public override void Update(ref float gravity, ref float maxFallSpeed) {
			Timer++;
			if (Timer > 2400) Item.active = false;
		}
        public override bool OnPickup(Player player) {
			int rand = Main.rand.Next(1, 3);
			player.statLife += rand;
			player.HealEffect(rand);
            return false;
        }
    }
}