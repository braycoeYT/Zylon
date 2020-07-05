using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes.Elemental
{
	public class GrandForestSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Grand Forest Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 190;
			npc.height = 130;
			npc.damage = 12;
			npc.defense = 2;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 1;
			animationType = 1;
			npc.npcSlots = 1f;
			npc.alpha = 50;
			if (NPC.downedPlantBoss)
			{
				npc.damage = 137;
				npc.lifeMax = 12000;
				npc.defense = 28;
				npc.value = 20000f;
				npc.aiStyle = 22;
				for (int k = 0; k < npc.buffImmune.Length; k++)
				{
					npc.buffImmune[k] = true;
				}
				npc.noGravity = true;
			    npc.noTileCollide = true;
			}
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 402;
            npc.damage = 29;
			if (NPC.downedPlantBoss)
			{
				npc.lifeMax = 21000;
				npc.damage = 212;
			}
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldDaySlime.Chance * 0.01f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 14 + Main.rand.Next(1));
			if (NPC.downedPlantBoss)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"), Main.rand.Next(2, 7));
				if (Main.rand.NextFloat() < .03f)
					Item.NewItem(npc.getRect(), mod.ItemType("TrueTreeTruncheon"));
			}
			else if (Main.rand.NextFloat() < .03f)
				Item.NewItem(npc.getRect(), mod.ItemType("TreeTruncheon"));
		}
	}
}