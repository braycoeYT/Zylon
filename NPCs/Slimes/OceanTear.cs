using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Slimes
{
	public class OceanTear : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 111;
			npc.defense = 9;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.aiStyle = 103;
			npc.knockBackResist = 1f;
			animationType = NPCID.GreenSlime;
			npc.npcSlots = 1f;
			npc.alpha = 150;
			npc.scale = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
		    npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ocean Tear");
			Main.npcFrameCount[npc.type] = 2;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 7500;
            npc.damage = 157;
			npc.defense = 19;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedPlantBoss)
			{
				if (spawnInfo.player.ZoneRockLayerHeight)
				{
			        return SpawnCondition.OceanMonster.Chance * 0.08f;
				}
				return 0f;
			}
		    return 0f;
        }
	}
}