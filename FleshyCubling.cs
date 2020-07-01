using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class FleshyCubling : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fleshy Cubling");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults()
		{
			npc.width = 27;
			npc.height = 27;
			npc.damage = 78;
			npc.defense = 9;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			animationType = 82;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 420;
            npc.damage = 105;
			npc.defense = 19;
			npc.alpha = 50;
        }
	}
}