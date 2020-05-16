using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses.Minions
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
			npc.width = 36;
			npc.height = 36;
			npc.damage = 209;
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
				if (Main.expertMode)
				{
					npc.aiStyle = 5;
					aiType = NPCID.Probe;
				}
				else
				npc.aiStyle = 63;
			}
			npc.buffImmune[20] = true;
			npc.buffImmune[21] = true;
			npc.buffImmune[22] = true;
			npc.buffImmune[23] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[25] = true;
			npc.buffImmune[30] = true;
			npc.buffImmune[31] = true;
			npc.buffImmune[32] = true;
			npc.buffImmune[33] = true;
			npc.buffImmune[35] = true;
			npc.buffImmune[36] = true;
			npc.buffImmune[37] = true;
			npc.buffImmune[38] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[44] = true;
			npc.buffImmune[46] = true;
			npc.buffImmune[47] = true;
			npc.buffImmune[67] = true;
			npc.buffImmune[68] = true;
			npc.buffImmune[69] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[72] = true;
			npc.buffImmune[80] = true;
			npc.buffImmune[86] = true;
			npc.buffImmune[88] = true;
			npc.buffImmune[94] = true;
			npc.buffImmune[144] = true;
			npc.buffImmune[148] = true;
			npc.buffImmune[149] = true;
			npc.buffImmune[153] = true;
			npc.buffImmune[156] = true;
			npc.buffImmune[160] = true;
			npc.buffImmune[163] = true;
			npc.buffImmune[164] = true;
			npc.buffImmune[169] = true;
			npc.buffImmune[192] = true;
			npc.buffImmune[194] = true;
			npc.buffImmune[195] = true;
			npc.buffImmune[196] = true;
			npc.buffImmune[197] = true;
			npc.buffImmune[199] = true;
			npc.buffImmune[203] = true;
			npc.buffImmune[204] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5152;
            npc.damage = 354;
			npc.defense = 90;
        }
	}
}