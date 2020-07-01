using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class Fosceye : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Focs Vanisheye");
			Main.npcFrameCount[npc.type] = 4;
		}
		
        public override void SetDefaults()
		{
			npc.width = 33;
			npc.height = 33;
			npc.damage = 155;
			npc.defense = 46;
			npc.lifeMax = 2000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 321f;
			npc.aiStyle = 39;
			npc.knockBackResist = 0f;
			animationType = 496;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3772;
            npc.damage = 287;
			npc.defense = 51;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Corruption.Chance * 0.1f;
			}
			return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 71;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
	        Item.NewItem(npc.getRect(), mod.ItemType("DarkSoul"));
        }
	}
}