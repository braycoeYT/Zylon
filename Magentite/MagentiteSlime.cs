using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Magentite
{
	public class MagentiteSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magentite Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 19;
			npc.defense = 1;
			npc.lifeMax = 59;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 131f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0.2f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 119;
            npc.damage = 35;
			npc.defense = 2;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Cavern.Chance * 0.07f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(2));
			Item.NewItem(npc.getRect(), mod.ItemType("MagentiteOre"), 1 + Main.rand.Next(3));
			if (Main.rand.NextFloat() < .003f)
				if (NPC.downedBoss2)
					Item.NewItem(npc.getRect(), mod.ItemType("MagentaMagnet"));
			if (Main.rand.NextFloat() < .02f)
				Item.NewItem(npc.getRect(), mod.ItemType("EyeCandy"));
		}
	}
}