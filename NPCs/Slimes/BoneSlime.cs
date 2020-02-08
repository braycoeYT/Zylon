using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class BoneSlime : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 41;
			npc.defense = 9;
			npc.lifeMax = 91;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 131f;
			npc.aiStyle = 1;
			npc.knockBackResist = 1f;
			animationType = NPCID.GreenSlime;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bone Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 189;
            npc.damage = 71;
			npc.defense = 10;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Dungeon.Chance * 0.1f;
        }
		
		public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), ItemID.Bone, 1 + Main.rand.Next(2));
            
        }
	}
}