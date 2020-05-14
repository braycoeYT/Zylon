using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Minions.Empress
{
	public class RoyalMotherSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Royal Mother Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 31;
			npc.height = 44;
			npc.damage = 61;
			npc.defense = 10;
			npc.lifeMax = 950;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1900;
            npc.damage = 122;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				float numberNPC = Main.rand.Next(2, 5);
				for (int i = 0; i < numberNPC; i++)
				{
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
				}
			}
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(4))
			{
				player.AddBuff(163, 300, true);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (WorldEdit.downedEmpress)
				return SpawnCondition.Cavern.Chance * 0.04f;
			return 0f;
		}
	}
}