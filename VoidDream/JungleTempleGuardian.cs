using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.VoidDream
{
	public class JungleTempleGuardian : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jungle Temple Guardian");
		}
		
        public override void SetDefaults()
		{
			npc.width = 100;
			npc.height = 108;
			npc.damage = 175000;
			npc.defense = 1750000;
			npc.lifeMax = 75000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.aiStyle = 11;
			npc.knockBackResist = 0f;
			aiType = NPCID.DungeonGuardian;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.voidDream)
			{
				if (!NPC.downedPlantBoss)
			    return SpawnCondition.JungleTemple.Chance * 1f;
			}
			return 0f;
        }
	}
}