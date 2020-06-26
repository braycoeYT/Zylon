using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minions.Empress
{
	public class SlimeLarva : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slime Larva");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 7;
			npc.height = 13;
			npc.damage = 42;
			npc.defense = 0;
			npc.lifeMax = 300;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
			npc.scale = 1.5f;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 600;
            npc.damage = 71;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode)
			if (Main.rand.NextBool(4))
			{
				player.AddBuff(163, 300, true);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (ZylonWorld.downedEmpress)
				return SpawnCondition.OverworldDay.Chance * 0.09f;
			return 0f;
		}
	}
}