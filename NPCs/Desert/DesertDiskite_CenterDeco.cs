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
	public class DesertDiskite_CenterDeco : ModNPC
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("");
            //Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.width = 34;
			NPC.height = 34;
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
			Banner = Item.NPCtoBanner(ModContent.NPCType<DesertDiskite_Center>());
			BannerItem = Item.BannerToItem(Banner);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
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
        }
    }
}