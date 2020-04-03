using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Discus
{
	public class IcyDiscus2 : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Icy Discus");
		}

        public override void SetDefaults()
		{
			npc.width = 55;
			npc.height = 55;
			npc.damage = 19;
			npc.defense = 1;
			npc.lifeMax = 45;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 75f;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 88;
            npc.damage = 38;
			npc.defense = 2;
			npc.knockBackResist = 0.2f;
        }
		
	    public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 1 + Main.rand.Next(1));
	        Item.NewItem(npc.getRect(), ItemID.Snowball, Main.rand.Next(0, 12));
        }
	}
}