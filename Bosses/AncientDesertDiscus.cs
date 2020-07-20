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
	public class AncientDesertDiscus : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ancient Desert Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 115;
			npc.height = 115;
			npc.damage = 14;
			npc.defense = 2;
			npc.lifeMax = 1300;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 56;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.lavaImmune = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/AncientDesertDiscusTheme");
			npc.netAlways = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1800;
            npc.damage = 28;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 216;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0)
			{
				npc.boss = false;
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("AncientDesertDiscus2"));
				if (Main.expertMode)
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ElectricalEntity"));
				Color messageColor = Color.CornflowerBlue;
				string chat = "I will defend Terraria with all my decaying might!";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
		}
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		public float RageTimer
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}

		bool chat0 = true;
		bool chat1 = true;
		bool chat2 = true;
		int flee = 0;

        public override void AI()
		{
			npc.TargetClosest(true);
			if (!Main.player[npc.target].ZoneDesert)
			{
				RageTimer++;

				if (RageTimer > 299)
					npc.dontTakeDamage = true;
				else
					npc.dontTakeDamage = false;
			}
			else
				RageTimer = 0;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
			}
			else
				flee = 0;
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
            }
			
			if (Main.dayTime)
			{
				npc.life += 5;
				npc.dontTakeDamage = true;
				if (npc.life > npc.lifeMax)
				{
					npc.life = npc.lifeMax;
					npc.lifeMax += 6;
				}
				if (chat2)
				{
					Color messageColor = Color.Orange;
					string chat = "This is dragging on forever...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat2 = false;
				}
				npc.noTileCollide = true;
                npc.velocity.Y = 8f;
			}
	        Timer++;
			if (Main.expertMode)
			{
				if  (Timer % 350 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Minions.Discus.SandGrainDiscus>(), 0, npc.whoAmI);
				}
			}
			else
			{
				if  (Timer % 450 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Minions.Discus.SandGrainDiscus>(), 0, npc.whoAmI);
				}
			}
        }
	}
}