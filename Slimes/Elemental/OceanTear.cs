using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes.Elemental
{
	public class OceanTear : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ocean Tear");
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 111;
			npc.defense = 9;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.aiStyle = 103;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.npcSlots = 1f;
			npc.alpha = 150;
			npc.scale = 1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 7500;
            npc.damage = 157;
			npc.defense = 19;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedPlantBoss)
			{
			    return SpawnCondition.OceanMonster.Chance * 0.08f;
			}
		    return 0f;
        }
		
		public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(1));
			if (Main.rand.Next(20) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("ElementamaxSludge"));
        }
	}
}