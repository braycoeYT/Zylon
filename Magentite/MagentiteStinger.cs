using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Magentite
{
	public class MagentiteStinger : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magentite Stinger");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 31;
			npc.defense = 0;
			npc.lifeMax = 49;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 131f;
			npc.aiStyle = 5;
			npc.knockBackResist = 0.1f;
			animationType = 1;
			aiType = 235;
			npc.noGravity = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 90;
            npc.damage = 62;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			if (WorldEdit.voidDream)
			{
				npc.noTileCollide = true;
			}
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Cavern.Chance * 0.07f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("MagentiteOre"), 1 + Main.rand.Next(3));
        }
	}
}