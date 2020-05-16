using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Magentite
{
	public class TibbleToppler : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tibble Toppler");
			Main.npcFrameCount[npc.type] = 12;
		}
		
        public override void SetDefaults()
		{
			npc.width = 33;
			npc.height = 33;
			npc.damage = 18;
			npc.defense = 10;
			npc.lifeMax = 61;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 100f;
			npc.aiStyle = 39;
			npc.knockBackResist = 0.3f;
			animationType = 496;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 123;
            npc.damage = 71;
			npc.defense = 14;
			npc.knockBackResist = 0.15f;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Cavern.Chance * 0.07f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.NextFloat() < .0125f)
	        Item.NewItem(npc.getRect(), ItemID.DepthMeter);
			if (Main.rand.NextFloat() < .0123f)
	        Item.NewItem(npc.getRect(), ItemID.Compass);
			if (Main.rand.NextFloat() < .039f)
	        Item.NewItem(npc.getRect(), ItemID.Rally);
			Item.NewItem(npc.getRect(), mod.ItemType("MagentiteOre"), 1 + Main.rand.Next(3));
        }
	}
}