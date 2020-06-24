using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class LavaJelly : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lava Jelly");
		}
        public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 28;
			npc.damage = 18;
			npc.defense = 10;
			npc.lifeMax = 67;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 100f;
			npc.aiStyle = 18;
			npc.knockBackResist = 1f;
			npc.noGravity = true;
			npc.lavaImmune = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 118;
            npc.damage = 34;
			npc.defense = 12;
			npc.scale = 1.2f;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Underworld.Chance * 0.1f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 0)
	            Item.NewItem(npc.getRect(), ItemID.Hellstone);
        }
	}
}