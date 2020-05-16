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
			npc.width = 62;
			npc.height = 62;
			npc.damage = 16;
			npc.defense = 2;
			npc.lifeMax = 2300;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 2000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 56;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 2;
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
            npc.lifeMax = 1020;
            npc.damage = 32;
			npc.defense = 5;
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
		}
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		bool chat0 = true;
		bool chat1 = true;
		bool chat2 = true;
		int flee = 0;

        public override void AI()
		{
			if (!Main.expertMode)
			{
				if (npc.velocity.X > 7)
				{
					npc.velocity.X = 6;
				}
				else if (npc.velocity.X < -7)
				{
					npc.velocity.X = -6;
				}
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
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat2 = false;
				}
				npc.noTileCollide = true;
                npc.velocity.Y = 8f;
			}
			else if (!Main.player[npc.target].ZoneDesert)
			{
				npc.dontTakeDamage = true;
				
				if (chat1)
				{
					Color messageColor = Color.Orange;
					string chat = "Don't try that, kid... You cannot flee my home...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat1 = false;
				}
			}
			else
			npc.dontTakeDamage = false;
	        Timer++;
			if (Main.expertMode)
			{
				if  (Timer % 350 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SandGrainDiscus>(), 0, npc.whoAmI);
				}
			}
			else
			{
				if  (Timer % 450 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SandGrainDiscus>(), 0, npc.whoAmI);
				}
			}
			
			if (npc.life < npc.lifeMax / 4)
			{
				if (chat0)
				{
					if (Main.expertMode)
					{
						npc.lifeMax = npc.lifeMax * 4/3;
						npc.life = npc.lifeMax;
						npc.defense += 5;
						npc.damage += 10;
						npc.scale = 2.5f;
						npc.width = 78;
						npc.height = 78;
						
						/*if (WorldEdit.voidDream)
						{
							npc.damage += 15;
							npc.scale = 3f;
							npc.width = 91;
							npc.height = 91;
						}*/
					}
					Color messageColor = Color.Orange;
					string chat = "Show me your true power, kid...";
					if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == 0)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat0 = false;
				}
			}
        }
		
	    public override void NPCLoot()
        {
			if (!WorldEdit.downedDiscus)
			{
				Color messageColor = Color.Orange;
				string chat = "As the Ancient Desert Discus dies, the other discuses flee into all of the other biomes...";
				if (Main.netMode == 2)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == 0)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
			
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DiscusBag"));
				if (!WorldEdit.downedDiscus)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DiscusStory"));
				}
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 4 + Main.rand.Next(2));
	            Item.NewItem(npc.getRect(), ItemID.Amber, 1 + Main.rand.Next(1));
			    Item.NewItem(npc.getRect(), ItemID.GoldBar, 1 + Main.rand.Next(1));
				Item.NewItem(npc.getRect(), mod.ItemType("ZylonianDesertCore"), Main.rand.Next(5, 9));
				if (Main.rand.NextFloat() < .5f)
				Item.NewItem(npc.getRect(), mod.ItemType("BandOfInfection"));
			}
			WorldEdit.downedDiscus = true;
        }
	}
}