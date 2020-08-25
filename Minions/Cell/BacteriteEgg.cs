using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Minions.Cell
{
	public class BacteriteEgg : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bacterite Egg");
		}

        public override void SetDefaults()
		{
			npc.width = 14;
			npc.height = 14;
			npc.damage = 7;
			npc.defense = 19;
			npc.lifeMax = 31;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 0f;
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 29;
            npc.damage = 9;
			npc.knockBackResist = 0.1f;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = mod.DustType("MicrobiomeDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int rand = Main.rand.Next(250, 601);
		float moveX = Main.rand.NextFloat(-1.5f, 1.5f);
		float moveY = Main.rand.NextFloat(-1.5f, 1.5f);
		public override void AI()
		{
			Timer++;
			if (Timer > rand)
			{
				npc.life = 0;
				Timer = 0;
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Bacterite2"));
			}
			npc.velocity.X = moveX;
			npc.velocity.Y = moveY;
			if (Timer % 20 == 0)
            {
				npc.velocity.X = npc.velocity.X / 2;
				npc.velocity.Y = npc.velocity.Y / 2;
			}
		}
	}
}