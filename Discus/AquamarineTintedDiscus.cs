using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class AquamarineTintedDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aquamarine Tinted Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 48;
			npc.damage = 29;
			npc.defense = 0;
			npc.lifeMax = 67;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 141;
            npc.damage = 59;
			npc.defense = 1;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (ZylonWorld.downedDiscus)
			{
				if(spawnInfo.player.ZoneBeach)
				return 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
		    if (Main.rand.NextFloat() < .1f)
	        Item.NewItem(npc.getRect(), ItemID.Coral);
			if (Main.rand.NextFloat() < .1f)
	        Item.NewItem(npc.getRect(), ItemID.Seashell);
			if (Main.rand.NextFloat() < .1f)
	        Item.NewItem(npc.getRect(), ItemID.Starfish);
			if (Main.rand.NextFloat() < .01f)
	        Item.NewItem(npc.getRect(), ItemID.JellyfishNecklace);
        }
	}
}