using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome
{
	public class DiseasedGoldfish : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blue Abyssal Goldfish");
			Main.npcFrameCount[npc.type] = 8;
		}

        public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 24;
			npc.damage = 33;
			npc.defense = 5;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 100f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 16;
			npc.noGravity = true;
			animationType = NPCID.CorruptGoldfish;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 200;
            npc.damage = 66;
			npc.knockBackResist = 0.9f;
			if (Main.hardMode)
			{
				npc.lifeMax = 220;
				npc.damage = 57;
			}
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
			if (npc.life <= 0)
			{
				if (Main.expertMode)
				{
					if (Main.rand.Next(7) == 0)
					{
						float numberNPC = Main.rand.Next(1, 3);
						for (int i = 0; i < numberNPC; i++)
						{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-25, 25), (int)npc.position.Y + Main.rand.Next(-25, 25), mod.NPCType("Globulite"));
						}
					}
				}
				else
				{
					if (Main.rand.Next(6) == 0)
					{
						float numberNPC = Main.rand.Next(1, 3);
						for (int i = 0; i < numberNPC; i++)
						{
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-25, 25), (int)npc.position.Y + Main.rand.Next(-25, 25), mod.NPCType("Globulite"));
						}
					}
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.1f : 0f;
		}
		
	    public override void NPCLoot()
        {
			if (Main.rand.Next(3) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
        }
	}
}