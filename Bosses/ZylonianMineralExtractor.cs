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
	public class ZylonianMineralExtractor : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
		}

        public override void SetDefaults()
		{
			npc.width = 300;
			npc.height = 480;
			npc.damage = 160;
			npc.defense = 67;
			npc.lifeMax = 105000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 40000f;
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
            npc.lifeMax = 177500;
            npc.damage = 226;
			npc.defense = 89;
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ZylonianMineralExtractorPha2"));
            }
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		int flee = 0;
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
			
			targetPos = Main.player[npc.target].Center;
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
		
			if (Main.expertMode)
			{
				if  (Timer % 300 == 0)
				{
					if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 6)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
					if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 8)
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
				}
			}
			else if  (Timer % 360 == 0)
			{
				if (NPC.CountNPCS(ModContent.NPCType<Minions.AquaSapphire>()) < 6)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.FlameGarnet>()) < 7)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
				if (NPC.CountNPCS(ModContent.NPCType<Minions.SproutingEmerald>()) < 7)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
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
        }
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name + "'s Outer Armor";
			potionType = ItemID.Amethyst;
		}
	}
}