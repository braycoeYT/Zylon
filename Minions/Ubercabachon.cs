using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Minions
{
	public class Ubercabachon : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ubercabachon");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 45;
			npc.height = 45;
			npc.damage = 109;
			npc.defense = 60;
			npc.lifeMax = 3987;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			if (Main.rand.Next(2) == 1)
			{
				npc.aiStyle = 63;
			}
			else
			{
				npc.aiStyle = 5;
				aiType = NPCID.Probe;
			}
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (ZylonWorld.downedMineral)
			return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
			return 0f;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5152;
            npc.damage = 199;
			npc.defense = 90;
        }
	}
}