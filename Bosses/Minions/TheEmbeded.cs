using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses.Minions
{
	public class TheEmbeded : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Embeded");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 35;
			npc.height = 35;
			npc.damage = 37;
			npc.defense = 25;
			npc.lifeMax = 700;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0.1f;
			npc.aiStyle = 10;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1100;
            npc.damage = 49;
			npc.defense = 35;
        }
	}
}