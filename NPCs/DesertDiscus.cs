using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class DesertDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Desert Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 55;
			npc.height = 55;
			npc.damage = 12;
			npc.defense = 3;
			npc.lifeMax = 33;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 76;
            npc.damage = 25;
			npc.defense = 6;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.OverworldDayDesert.Chance * 1f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
            if (Main.rand.NextFloat() < .153f)
	        Item.NewItem(npc.getRect(), ItemID.GoldenKey);
		    if (Main.rand.NextFloat() < .04f)
	        Item.NewItem(npc.getRect(), ItemID.BoneWand);
		    if (Main.rand.NextFloat() < .011f)
	        Item.NewItem(npc.getRect(), ItemID.ClothierVoodooDoll);
		    if (Main.rand.NextFloat() < .022f)
	        Item.NewItem(npc.getRect(), ItemID.AncientNecroHelmet);
		    if (Main.rand.NextFloat() < .2f)
	        Item.NewItem(npc.getRect(), 3095);
        }
	}
}