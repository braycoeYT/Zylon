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
	public class Meatball : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meatball");
		}

        public override void SetDefaults()
		{
			npc.width = 150;
			npc.height = 150;
			npc.damage = 55;
			npc.defense = 7;
			npc.lifeMax = 3200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 5000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 6400;
            npc.damage = 88;
			npc.defense = 10;
			npc.lavaImmune = true;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 9600;
				npc.damage = 115;
				npc.defense = 13;
				aiType = NPCID.Gastropod;
			}
        }
		
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MeatballBag"));
				if (!WorldEdit.downedMeatball)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("MeatballStory"));
				}
			}
		    else
			{
			int ran = Main.rand.Next(1, 4);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtyDiscus"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtyHarp"));
			if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("DirtyPistol"));
			}
			WorldEdit.downedMeatball = true;
        }
		
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedBoss3)
			{
				if(Main.bloodMoon)
			    return 0.01f;
			}
			return 0f;
        }*/
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(16) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Drippler, 0, npc.whoAmI);
			}
			
			if (Main.rand.Next(20) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RedSlime, 0, npc.whoAmI);
		}
	}
}