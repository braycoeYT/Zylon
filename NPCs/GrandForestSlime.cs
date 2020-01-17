using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class GrandForestSlime : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 120;
			npc.height = 120;
			npc.damage = 12;
			npc.defense = 2;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 1;
			animationType = NPCID.GreenSlime;
			npc.npcSlots = 1f;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Grand Forest Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 402;
            npc.damage = 29;
			npc.defense = 4;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldDaySlime.Chance * 0.01f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
        }
	}
}