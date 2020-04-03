using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class FleshyCubling : ModNPC
	{
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 78;
			npc.defense = 9;
			npc.lifeMax = 600;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
        }
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleshy Cubling");
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 990;
            npc.damage = 105;
			npc.defense = 19;
			npc.alpha = 150;
        }
	}
}