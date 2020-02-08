using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Zylon.NPCs
{
	public class DankSoullessEater : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Darkness Chaser");
		}

        public override void SetDefaults()
		{
			npc.width = 57;
			npc.height = 38;
			npc.damage = 156;
			npc.defense = 38;
			npc.lifeMax = 7100;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 888;
			npc.knockBackResist = 1f;
			npc.aiStyle = 10;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 9200;
            npc.damage = 289;
			npc.defense = 41;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Corruption.Chance * 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
            if (Main.rand.Next(2) == 0)
	            Item.NewItem(npc.getRect(), mod.ItemType("DankSoul"));
        }
	}
}