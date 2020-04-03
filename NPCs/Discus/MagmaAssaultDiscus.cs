using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class MagmaAssaultDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magma Assualt Discus");
		}

        public override void SetDefaults()
		{
			npc.value = 125f;
			npc.width = 33;
			npc.height = 33;
			npc.damage = 76;
			npc.defense = 5;
			npc.lifeMax = 124;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 201;
            npc.damage = 109;
			npc.defense = 8;
			npc.knockBackResist = 0f;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedDiscus)
			{
				if(spawnInfo.player.ZoneUnderworldHeight)
				if(Main.expertMode)
				return 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .05f)
	        Item.NewItem(npc.getRect(), ItemID.Hellstone);
        }
	}
}