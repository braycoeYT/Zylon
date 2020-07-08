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
using static Zylon.ZylonWorld;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ZylonianMineralExtractor : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
		}

        public override void SetDefaults()
		{
			npc.width = 275;
			npc.height = 480;
			npc.damage = 137;
			npc.defense = 49;
			npc.lifeMax = 175000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 1500000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1; //51 original
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 265000;
            npc.damage = 209;
			npc.defense = 61;
        }
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.expertMode)
			{
				target.AddBuff(mod.BuffType("Crystalizing"), 15, false);
				target.AddBuff(BuffID.Slow, 200, false);
				target.AddBuff(BuffID.Bleeding, 200, false);
				target.AddBuff(BuffID.Venom, 200, false);
				target.AddBuff(BuffID.Frostburn, 200, false);
			}
			else
			{
				target.AddBuff(mod.BuffType("Crystalizing"), 10, false);
				target.AddBuff(BuffID.Poisoned, 100, false);
				target.AddBuff(BuffID.Frostburn, 45, false);
			}
		}
		int flee = 0;
		int dashInt = 0;
		int nukeTimer = 0;
		int nukeTimer2 = 0;
		int uberTimer = 0;
		bool dash = false;
		bool nuke = true;
		bool nukeChat = true;
		bool nuke2 = true;
		bool nukeChat2 = true;
		bool uber = true;
		bool uberChat = true;
		bool playerBadChat = true;
		Vector2 targetPos;
		
        public override void AI()
		{
	        Timer++;
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
				if (flee >= 100 && playerBadChat)
				{
					Color messageColor = Color.Pink;
					string chat = "<ZYL-900> Beginning Mass Mineral Extraction on Terraria...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					playerBadChat = false;
				}
            }
			
			if (Main.dayTime)
			{
				npc.life = npc.lifeMax;
				npc.active = false;
				Color messageColor = Color.Pink;
				string chat = "<ZYL-900> Too hot for host's homeostasis to continue and heat guards are broken. Leaving to protect host body...";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
			
			targetPos = Main.player[npc.target].Center;
			Player target = Main.player[npc.target];
			/*if (dash)
			{
				int dashMax;
				targetPos = Main.player[npc.target].Center;
				npc.velocity.X = 0;

				if (npc.life < npc.lifeMax / 2)
				{
					dashMax = 4;
				}
				else if (npc.life < npc.lifeMax / 3)
				{
					dashMax = 5;
				}
				else if (npc.life < npc.lifeMax / 4)
				{
					dashMax = 6;
				}
				else if (npc.life < npc.lifeMax / 5)
				{
					dashMax = 7;
				}
				else if (npc.life < 40000)
				{
					dashMax = 8;
				}
				else
				{
					dashMax = 3;
				}

				if (dashInt >= dashMax)
					dash = false;

				if (npc.Center.Y - 600 > targetPos.Y)
				{
					dashInt += 1;
					npc.position.X = targetPos.X + (Main.player[npc.target].velocity.X * 30);
					npc.position.Y = targetPos.Y - 1200;
					Main.PlaySound(SoundID.ForceRoar, npc.position, 0);
				}

				if (npc.life < npc.lifeMax / 3)
				{
					npc.velocity.Y = 21;
				}
				else if (npc.life < npc.lifeMax / 4)
				{
					npc.velocity.Y = 24;
				}
				else
				{
					npc.velocity.Y = 18;
				}
			}
			else
			{*/
				if (targetPos.X > npc.Center.X)
				{
					if (Main.expertMode)
						if (npc.velocity.X < 0)
							npc.velocity.X = 2;

					if (Timer % 30 == 0)
						npc.velocity.X += 1;
				}
				if (targetPos.X < npc.Center.X)
				{
					if (Main.expertMode)
						if (npc.velocity.X > 0)
							npc.velocity.X = -2;

					if (Timer % 30 == 0)
						npc.velocity.X -= 1;
				}
				if (targetPos.Y + 300 < npc.Center.Y)
				{
					npc.velocity.Y = -30;
					Main.PlaySound(SoundID.Tink, npc.position, 0);
				}
				else if (targetPos.Y + 300 > npc.Center.Y)
				{
					if (Main.expertMode)
					{
						if (Timer % 5 == 0)
							npc.velocity.Y += 2;
					}
					else
					{
						if (npc.lifeMax / 2 > npc.life)
						{
							if (Timer % 6 == 0)
								npc.velocity.Y += 2;
						}
						else
						{
							if (Timer % 5 == 0)
								npc.velocity.Y += 2;
						}
					}
				}
				else
					npc.velocity.Y = 1;
			//}
		
			if (Main.expertMode)
			{
				if  (Timer % 400 == 0)
				{
					if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
				}
			}
			else if  (Timer % 440 == 0)
			{
				if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
			}

			/*if (Main.expertMode && npc.life < npc.lifeMax / 1.4)
			{
				int dashSpeed;
				if (npc.life < npc.lifeMax / 2)
					dashSpeed = 800;
				else if (npc.life < npc.lifeMax / 3.5)
					dashSpeed = 700;
				else if (npc.life < npc.lifeMax / 5.7)
					dashSpeed = 600;
				else
					dashSpeed = 900;
				if (Timer % dashSpeed == 0)
				{
					dash = true;
					dashInt = 0;
				}
			}*/
			//ZylonWorld.ZMETarget = targetPos;
			if ((Timer % 829 == 0 && !Main.expertMode) || (Timer % 787 == 0 && Main.expertMode))
			{
				NPC.NewNPC((int)targetPos.X, (int)targetPos.Y, NPCType<Minions.Mineral.TargetMegaLaser>(), 0, npc.whoAmI);
			}
			if ((Timer % 480 == 95 && !Main.expertMode) || (Timer % 420 == 247 && Main.expertMode))
			{
				NPC.NewNPC((int)targetPos.X, (int)targetPos.Y, NPCType<Minions.Mineral.TargetMegaRandom>(), 0, npc.whoAmI);
			}
			if (Main.expertMode && Timer % 1000 == 0)
			{
				NPC.NewNPC((int)targetPos.X, (int)targetPos.Y, NPCType<Minions.Mineral.TargetMineralBeam>(), 0, npc.whoAmI);
			}
			if (100000 > npc.life && uber)
			{
				uberTimer++;
				if (uberTimer > 90 || (uberTimer > 60 && !Main.expertMode))
				{
					uber = false;
				}
				if (uberTimer % 5 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Ubercabachon>(), 0, npc.whoAmI);
				}
				if (uberChat)
				{
					uberChat = false;
					Color messageColor = Color.Pink;
					string chat = "<ZYL-900> Low health detected! Releasing ubercabachons!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				uberChat = false;
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
				Item.NewItem(npc.getRect(), ItemID.Amethyst, Main.rand.Next(10, 26));
			}
			ZylonWorld.downedMineral = true;
		}
	}
}