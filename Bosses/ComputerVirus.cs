using Zylon;
using Zylon.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ComputerVirus : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus");
		}

        public override void SetDefaults()
		{
			npc.width = 165;
			npc.height = 165;
			npc.damage = 75;
			npc.defense = 30;
			npc.lifeMax = 18000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = MusicID.Boss1;
			npc.netAlways = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			aiType = NPCID.TheHungry;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 30000;
            npc.damage = 105;
			npc.defense = 45;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 42000;
				npc.damage = 145;
				npc.defense = 55;
			}
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		bool fleeChat = true;
		int flee = 0;

        public override void AI()
		{
			if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ComputerVirusPha2"));
            }
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (flee >= 350)
                    npc.active = false;
            }
			
			if (Main.dayTime)
			{
				npc.life = npc.lifeMax;
				if (fleeChat)
				{
					Color messageColor = Color.Gray;
					string chat = "Mode: Leaving";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					fleeChat = false;
				}
				npc.noTileCollide = true;
                npc.velocity.Y = 16f;
			}
			
	        Timer++;
			if (WorldEdit.voidDream)
			{
				if  (Timer % 350 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 150 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 350 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			else if (Main.expertMode)
			{
				if  (Timer % 250 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Probe, 0, npc.whoAmI);
				}
				if  (Timer % 550 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 200 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 550 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			else
			{
				if  (Timer % 500 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 250 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Probe, 0, npc.whoAmI);
				}
				if  (Timer % 740 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			
			if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ComputerVirusPha2"));
            }
			
			if (Timer > 1500)
			{
				Timer = 0;
			}
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ComputerVirusPha2"));
            }
        }
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.CopperCoin;
		}
	}
}