using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;

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
			Item.value = Item.sellPrice(0, 0, 0, 69);
			Item.rare = ItemRarityID.LightPurple;
		}
		int Timer;
		public override void Update(ref float gravity, ref float maxFallSpeed) {
			Timer++;
			if (Timer > 600) Item.active = false;
		}
        public override bool ItemSpace(Player player) {
            return true;
        }
        public override bool OnPickup(Player player) {
			int rand = Main.rand.Next(1, 4);
			player.statLife += rand;
			player.HealEffect(rand);
			for (int i = 0; i < 36; i++) {
				Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.PurpleTorch);
				dust.noGravity = true;
				dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*10));
				dust.scale = 3f;
            }
			SoundEngine.PlaySound(SoundID.NPCHit44, player.position);
            return false;
        }
    }
}