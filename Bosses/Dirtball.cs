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
	public class Dirtball : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirtball");
		}

        public override void SetDefaults()
		{
			npc.width = 150;
			npc.height = 150;
			npc.damage = 39;
			npc.defense = 1;
			npc.lifeMax = 850;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 590f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 22;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Ichor] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1320;
            npc.damage = 81;
			npc.defense = 2;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			if (WorldEdit.voidDream)
			{
				npc.lifeMax = 1670;
				npc.damage = 95;
				npc.defense = 3;
			}
        }
		
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DirtballBag"));
				if (!WorldEdit.downedDirtball)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DirtballStory"));
				}
			}
		    else
			{
			int ran = Main.rand.Next(1, 7);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtyDiscus"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtyHarp"));
			if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("DirtyPistol"));
			if (ran == 5) Item.NewItem(npc.getRect(), mod.ItemType("DirtyJar"));
			if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("DirtYoyo"));
			if (ran == 7) Item.NewItem(npc.getRect(), mod.ItemType("DirtBow"));
			
			ran = Main.rand.Next(1, 3);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("DirtballHelmet"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtballGuardplate"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtballLeggings"));
			
			Item.NewItem(npc.getRect(), ItemID.CopperBar, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.DirtBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.MudBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Lens, 1 + Main.rand.Next(1));
			
			if (Main.rand.NextFloat() < .5f)
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("DirtyMedal"));
			}
			
			WorldEdit.downedDirtball = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (!WorldEdit.downedDirtball)
			{
				if(Main.dayTime)
			    return 0.00075f;
			}
			return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.expertMode)
			{
				if (Main.rand.Next(500) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.MotherSlime, 0, npc.whoAmI);
			    if (Main.rand.Next(320) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Pinky, 0, npc.whoAmI);
			    if (Main.rand.Next(55) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RedSlime, 0, npc.whoAmI);
			    if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BlueSlime, 0, npc.whoAmI);
			    if (Main.rand.Next(15) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GreenSlime, 0, npc.whoAmI);
			}
			
			if (Main.rand.Next(20) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GreenSlime, 0, npc.whoAmI);
		}
	}
}