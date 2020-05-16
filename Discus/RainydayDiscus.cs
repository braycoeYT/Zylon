using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class RainydayDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Rainyday Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 21;
			npc.defense = 0;
			npc.lifeMax = 91;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 90f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 181;
            npc.damage = 49;
			npc.defense = 4;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedDiscus)
			{
				if(spawnInfo.player.ZoneRain)
				return 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
			if (Main.rand.NextFloat() < .6f)
	        Item.NewItem(npc.getRect(), mod.ItemType("RainShard"));
        }
	}
}