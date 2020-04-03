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
	public class ComputerVirusClone : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Virus");
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
			npc.aiStyle = 23;
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
			animationType = 48;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5000;
            npc.damage = 125;
			npc.defense = 0;
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
			
			if (Main.dayTime)
			{
				npc.life = npc.lifeMax;
				npc.noTileCollide = true;
                npc.velocity.Y = 16f;
			}
			
			Timer++;
			
			if (Main.expertMode)
			{
				if  (Timer % 750 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Spammer>(), 0, npc.whoAmI);
				}
				if  (Timer % 500 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.TheEmbeded>(), 0, npc.whoAmI);
				}
				if  (Timer % 625 == 0)
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
			Color messageColor = Color.Purple;
			string chat = "F A T A L     E R R O R";
			if (Main.netMode == 2)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
			}
			else if (Main.netMode == 0)
			{
				Main.NewText(Language.GetTextValue(chat), messageColor);
			}
        }
	}
}