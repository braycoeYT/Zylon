using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class CocoaTintedDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cocoa Tinted Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 55;
			npc.height = 55;
			npc.damage = 38;
			npc.defense = 0;
			npc.lifeMax = 79;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 100f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 153;
            npc.damage = 71;
			npc.defense = 0;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedDiscus)
			{
				if(spawnInfo.player.ZoneMeteor)
				return 0.14f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .03f)
	        Item.NewItem(npc.getRect(), ItemID.Meteorite);
        }
	}
}