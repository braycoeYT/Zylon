using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Zylon.NPCs.Desert
{
	public class Adenite_SpikeRing : ModNPC
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Desert Diskite");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.width = 64;
			NPC.height = 64;
			NPC.damage = 16;
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
			Banner = Item.NPCtoBanner(ModContent.NPCType<Adenite_Center>());
			BannerItem = Item.BannerToItem(Banner);
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 69;
			NPC.damage = 32;
        }
        NPC main;
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer > 2) {
				main = Main.npc[(int)NPC.ai[0]];
				NPC.Center = main.Center;
				if (main.life < 1 || !main.active)
					NPC.active = false;
            }
			NPC.rotation += MathHelper.ToRadians(5);
        }
    }
}