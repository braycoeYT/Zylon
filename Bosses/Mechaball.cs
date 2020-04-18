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
	public class Mechaball : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mechaball");
		}

        public override void SetDefaults()
		{
			npc.width = 130;
			npc.height = 130;
			npc.damage = 101;
			npc.defense = 71;
			npc.lifeMax = 30000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
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
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			aiType = NPCID.Gastropod;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 50000;
            npc.damage = 182;
			npc.defense = 84;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 70000;
				npc.damage = 244;
				npc.defense = 96;
			}
        }
		
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MechaballBag"));
				if (!WorldEdit.downedMechaball)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("MechaballStory"));
				}
			}
		    else
			{
			int ran = Main.rand.Next(1, 7);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("Electropierce"));
			if (ran == 2) Item.NewItem(npc.getRect(), 2800);
			if (ran == 3) Item.NewItem(npc.getRect(), 2797);
			if (ran == 4) Item.NewItem(npc.getRect(), 2795);
			if (ran == 5) Item.NewItem(npc.getRect(), 2882);
			if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("Mechabow"));
			
			Item.NewItem(npc.getRect(), 2860, 20 + Main.rand.Next(20));
			Item.NewItem(npc.getRect(), ItemID.Bubble, 10 + Main.rand.Next(20));
			if (Main.rand.NextFloat() < .1f)
			Item.NewItem(npc.getRect(), 2864);
			}
			
			WorldEdit.downedMechaball = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.MartianMadness.Chance * 0.04f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(15) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Mechadrippler"), 0, npc.whoAmI);
			}
			if (WorldEdit.voidDream)
			{
				if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Mechadrippler"), 0, npc.whoAmI);
			}
		}
	}
}