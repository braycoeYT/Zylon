using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
	public class ADD_SpikeRing : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Diskite Director");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.width = 144;
			NPC.height = 144;
			NPC.damage = 0;
			NPC.defense = 9999;
			NPC.lifeMax = 69;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.aiStyle = -1;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.dontCountMe = true;
			NPC.dontTakeDamage = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            NPC.lifeMax = 69;
			NPC.damage = 0;
        }
        NPC main;
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer > 2) {
				main = Main.npc[ZylonGlobalNPC.diskiteBoss];
				NPC.Center = main.Center + main.velocity;
				if (((main.life < 1 && !Main.expertMode) || (main.lifeMax == 400 && Main.expertMode)) || !main.active) NPC.life = 0;
				if (NPC.lifeMax != 400) NPC.rotation += MathHelper.ToRadians(5f+(5f*main.life/main.lifeMax));
				else NPC.rotation += MathHelper.ToRadians(10);
				if (NPC.life == 0) {
					for (int i = 0; i < 12; i++) Gore.NewGore(NPC.GetSource_FromAI(), NPC.Center, new Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-6, 6)), ModContent.GoreType<Gores.Bosses.ADD.SpikeRingDeath>());
                }
            }
        }
    }
}