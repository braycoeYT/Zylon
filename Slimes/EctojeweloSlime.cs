using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class EctojeweloSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ectojewelo Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 174;
			npc.defense = 75;
			npc.lifeMax = 7948;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 5000f;
			npc.aiStyle = 1;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 10089;
            npc.damage = 271;
			npc.defense = 100;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedMineral)
			{
				if(spawnInfo.player.ZoneRockLayerHeight)
				return 0.1f;
				else
				return 0f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("EctojeweloOre"), 2 + Main.rand.Next(4));
        }
	}
}