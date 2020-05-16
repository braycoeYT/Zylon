using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class SandGrainDiscusSpawn : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sandgrain Assualt Discus");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 77;
			npc.height = 67;
			npc.damage = 25;
			npc.defense = 3;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 170;
            npc.damage = 30;
			npc.defense = 6;
			npc.knockBackResist = 0f;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedDiscus)
			{
				if(spawnInfo.player.ZoneUndergroundDesert)
				if(Main.expertMode)
				return 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .03f)
	        Item.NewItem(npc.getRect(), ItemID.Nazar);
        }
	}
}