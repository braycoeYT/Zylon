using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minions.Cell
{
	public class Stalker : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stalker");
		}

        public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 44;
			npc.damage = 23;
			npc.defense = 8;
			npc.lifeMax = 81;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.knockBackResist = 0.28f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 151;
            npc.damage = 41;
			npc.knockBackResist = 0.31f;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 40;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}