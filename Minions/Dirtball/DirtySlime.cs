using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minions.Dirtball
{
	public class DirtySlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirty Slime");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 18;
			npc.damage = 19;
			npc.defense = 1;
			npc.lifeMax = 26;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.alpha = 50;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 37;
            npc.damage = 31;
        }
	}
}