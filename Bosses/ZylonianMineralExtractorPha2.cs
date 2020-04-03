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
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
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
		int timer = 0;
		
        public override void AI()
		{
			
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
			}
		    else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), Main.rand.Next(15, 30));
			}
			WorldEdit.downedMineral = true;
        }
	}
}