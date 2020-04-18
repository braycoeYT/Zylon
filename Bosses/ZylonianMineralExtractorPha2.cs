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
	public class ZylonianMineralExtractorPha2 : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
		}

        public override void SetDefaults()
		{
			npc.width = 300;
			npc.height = 480;
			npc.damage = 240;
			npc.defense = 37;
			npc.lifeMax = 35000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 200000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 32;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
			npc.netAlways = true;
						npc.buffImmune[20] = true;
			npc.buffImmune[21] = true;
			npc.buffImmune[22] = true;
			npc.buffImmune[23] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[25] = true;
			npc.buffImmune[30] = true;
			npc.buffImmune[31] = true;
			npc.buffImmune[32] = true;
			npc.buffImmune[33] = true;
			npc.buffImmune[35] = true;
			npc.buffImmune[36] = true;
			npc.buffImmune[37] = true;
			npc.buffImmune[38] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[44] = true;
			npc.buffImmune[46] = true;
			npc.buffImmune[47] = true;
			npc.buffImmune[67] = true;
			npc.buffImmune[68] = true;
			npc.buffImmune[69] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[72] = true;
			npc.buffImmune[80] = true;
			npc.buffImmune[86] = true;
			npc.buffImmune[88] = true;
			npc.buffImmune[94] = true;
			npc.buffImmune[144] = true;
			npc.buffImmune[148] = true;
			npc.buffImmune[149] = true;
			npc.buffImmune[153] = true;
			npc.buffImmune[156] = true;
			npc.buffImmune[160] = true;
			npc.buffImmune[163] = true;
			npc.buffImmune[164] = true;
			npc.buffImmune[169] = true;
			npc.buffImmune[192] = true;
			npc.buffImmune[194] = true;
			npc.buffImmune[195] = true;
			npc.buffImmune[196] = true;
			npc.buffImmune[197] = true;
			npc.buffImmune[199] = true;
			npc.buffImmune[203] = true;
			npc.buffImmune[204] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 59000;
            npc.damage = 330;
			npc.defense = 59;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 86000 + numPlayers * 9000;
				npc.damage = 389;
				npc.defense = 71;
			}
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		bool Uber1 = true;
		bool Uber2 = true;
		bool Uber3 = true;
		bool Chat1 = true;
		bool Chat2 = true;
		bool Chat3 = true;
		bool Chat4 = true;
		bool Chat5 = true;
		bool Chat6 = true;
		bool Chat7 = true;
		int flee = 0;
		int timer = 0;
		
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
                npc.velocity.Y = 7f;
                if (flee >= 350)
                    npc.active = false;
            }
			
			if (Main.dayTime)
			{
				npc.life += 4321;
				if (npc.life > npc.lifeMax)
				{
					npc.life = npc.lifeMax;
				}
				npc.noTileCollide = true;
                npc.velocity.Y = 12f;
				npc.active = false;
			}
			
			if (Uber1)
			{
				if (Chat1)
				{
				Color messageColor = Color.Pink;
					string chat = "<XYL-900>: Critical condition, releasing Ubercabachons...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				timer++;
				if (timer % 6 == 1)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Ubercabachon>(), 0, npc.whoAmI);
				if (timer > 60)
				{
					Uber1 = false;
					timer = 0;
				}
				Chat1 = false;
			}
			
			if (npc.life < npc.lifeMax / 2)
			{
				if (Uber2)
				{
				if (Chat2)
				{
				Color messageColor = Color.Pink;
					string chat = "<XYL-900>: Critical condition, releasing Ubercabachons...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				timer++;
				if (timer % 6 == 1)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Ubercabachon>(), 0, npc.whoAmI);
				if (timer > 60)
				{
					Uber2 = false;
					timer = 0;
				}
				Chat2 = false;
				}
			}
			
			if (npc.life < npc.lifeMax / 3)
			{
				if (Uber3)
				{
				if (Chat3)
				{
				Color messageColor = Color.Pink;
					string chat = "<XYL-900>: Critical condition, releasing Ubercabachons...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				timer++;
				if (timer % 6 == 1)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Ubercabachon>(), 0, npc.whoAmI);
				if (timer > 60)
				{
					Uber3 = false;
					timer = 0;
				}
				Chat3 = false;
				}
			}
			
			if (Main.expertMode)
			{
				if (NPC.AnyNPCs(NPCType<Minions.Ubercabachon>()))
				{
					npc.dontTakeDamage = true;
				}
				else
				{
					npc.dontTakeDamage = false;
				}
			}
			if (!WorldEdit.downedMineral)
			{
			if (npc.life < 10000)
			{
				if (Chat4)
				{
					Color messageColor = Color.Pink;
					string chat = "Please...hero...save me from this mechanical menace...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					Chat4 = false;
				}
			}
			
			if (npc.life < 9000)
			{
				if (Chat5)
				{
					Color messageColor = Color.Pink;
					string chat = "<XYL-900>: I'm about to die... I'm about to fail Toxeye...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					Chat5 = false;
				}
			}
			}
			if (Main.expertMode)
			{
			if (npc.life < 7500)
			{
				if (Chat6)
				{
					Color messageColor = Color.Pink;
					string chat = "<XYL-900>: ACTIVATE SELF-DESTRUCT MODE! PREPARE TO DIE!";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					
					npc.damage = 9999999;
			        npc.defense = 0;
					Chat6 = false;
				}
			}
			}
			if (!WorldEdit.downedMineral)
			{
			if (npc.life < 1000)
			{
				if (Chat7)
				{
					Color messageColor = Color.Pink;
					string chat = "Thank you, hero... destroy Neozyl, Toxeye, and all of the other Zylonians. I would tell you their plans, but I am dying...take my blessing...goodbye...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					Chat7 = false;
				}
			}
			}
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name;
			potionType = ItemID.SuperHealingPotion;
		}
		
	    public override void NPCLoot()
        {
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MineralBag"));
				if (!WorldEdit.downedMineral)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("StoryMineral"));
				}
			}
		    else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), Main.rand.Next(15, 30));
			}
			WorldEdit.downedMineral = true;
        }
	}
}