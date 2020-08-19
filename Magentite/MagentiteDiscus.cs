using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Magentite
{
	public class MagentiteDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magentite Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 22;
			npc.defense = 0;
			npc.lifeMax = 107;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 115f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 211;
            npc.damage = 39;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedDiscus)
			{
				return SpawnCondition.Cavern.Chance * 0.07f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
			Item.NewItem(npc.getRect(), mod.ItemType("MagentiteOre"), 1 + Main.rand.Next(3));
			if (Main.rand.NextFloat() < .003f)
				if (NPC.downedBoss2)
					Item.NewItem(npc.getRect(), mod.ItemType("MagentaMagnet"));
			if (Main.rand.NextFloat() < .02f)
				Item.NewItem(npc.getRect(), mod.ItemType("EyeCandy"));
		}
	}
}