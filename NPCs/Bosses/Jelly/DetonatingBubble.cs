using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Jelly
{
	public class DetonatingBubble : ModNPC
	{
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
			NPC.CloneDefaults(NPCID.DetonatingBubble);
			NPC.damage = 60;
        }
		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.damage = 90;
			if (Main.getGoodWorld) NPC.scale = 1.5f;
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo) {
			for (int i = 0; i < 10; i++) {
				int dustType = ModContent.DustType<Dusts.WaterDust>();
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = NPC.velocity.X * -0.5f;
				dust.velocity.Y = NPC.velocity.Y * -0.5f;
				dust.scale *= 0.33f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void HitEffect(NPC.HitInfo hit) {
			for (int i = 0; i < (int)(10*NPC.scale); i++) {
				int dustType = ModContent.DustType<Dusts.WaterDust>();;
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity = new Microsoft.Xna.Framework.Vector2();
				dust.noGravity = false;
				dust.scale *= 0.33f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}