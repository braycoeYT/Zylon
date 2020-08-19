using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class FleshySlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleshy Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 89;
			npc.defense = 9;
			npc.lifeMax = 1500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 354f;
			npc.aiStyle = 1;
			npc.knockBackResist = 1f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 2750;
            npc.damage = 111;
			npc.defense = 11;
        }
		
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(4))
			{
				player.AddBuff(69, 300, true);
			}
		}
		
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Crimson.Chance * 0.1f;
			}
			return 0f;
        }*/
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
	        Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
        }
	}
}