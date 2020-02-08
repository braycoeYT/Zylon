using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class StarfurrySlime : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 31;
			npc.defense = 4;
			npc.lifeMax = 113;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 53f;
			npc.aiStyle = 14;
			npc.knockBackResist = 1f;
			animationType = NPCID.GreenSlime;
			npc.noGravity = true;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Starfurry Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 197;
            npc.damage = 71;
			npc.defense = 12;
			npc.noTileCollide = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Sky.Chance * 0.1f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(50) == 0)
	            Item.NewItem(npc.getRect(), ItemID.Starfury);
        }
	}
}