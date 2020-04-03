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
using Zylon.Items;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ComputerVirusPha2 : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus V2");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 165;
			npc.height = 165;
			npc.damage = 105;
			npc.defense = 30;
			npc.lifeMax = 8000;
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
			animationType = 48;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 13000 + numPlayers * 5000;
            npc.damage = 135;
			npc.defense = 45;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 15000;
				npc.damage = 161;
				npc.defense = 50;
			}
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		bool fleeChat = true;
		bool Chat1 = true;
		int flee = 0;

        public override void AI()
		{		
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
                npc.velocity.Y = 9f;
                if (flee >= 350)
                    npc.active = false;
            }
			
			if (Chat1)
				{
					Color messageColor = Color.Gray;
					string chat = "You cannot kill me, you antivirus.";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					
					if (WorldEdit.voidDream)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<ComputerVirusClone>(), 0, npc.whoAmI);
					}
					
					Chat1 = false;
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
				if  (Timer % 320 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 125 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 300 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			else if (Main.expertMode)
			{
				if  (Timer % 620 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 250 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 500 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			else
			{
				if  (Timer % 300 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 680 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 600 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cookie>(), 0, npc.whoAmI);
				}
			}
			if (Timer > 1500)
			{
				Timer = 0;
			}
        }
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.GreaterHealingPotion;
		}
		
		public override void NPCLoot()
        {
			Color messageColor = Color.Gray;
			string chat = "F A T A L     E R R O R";
			if (Main.netMode == 2)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(Language.GetTextValue(chat), messageColor);
			}
			
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("ComVirusBag"));
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("SoulOfByte"), Main.rand.Next(20, 45));
	            Item.NewItem(npc.getRect(), ItemID.HallowedBar, Main.rand.Next(15, 30));
			}
			WorldEdit.downedComVirus = true;
        }
	}
}