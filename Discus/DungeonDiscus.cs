using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class DungeonDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dungeon Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 55;
			npc.height = 55;
			npc.damage = 31;
			npc.defense = 8;
			npc.lifeMax = 84;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 90f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 161;
            npc.damage = 58;
			npc.defense = 13;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (WorldEdit.downedDiscus)
			{
				if(spawnInfo.player.ZoneDungeon)
				return 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .7f)
	        Item.NewItem(npc.getRect(), ItemID.BlueBrick, Main.rand.Next(0,3));
			if (Main.rand.NextFloat() < .7f)
	        Item.NewItem(npc.getRect(), ItemID.GreenBrick, Main.rand.Next(0,3));
			if (Main.rand.NextFloat() < .7f)
	        Item.NewItem(npc.getRect(), ItemID.PinkBrick, Main.rand.Next(0,3));
			if (Main.rand.NextFloat() < .05f)
	        Item.NewItem(npc.getRect(), ItemID.GoldenKey, Main.rand.Next(0,3));
        }
	}
}