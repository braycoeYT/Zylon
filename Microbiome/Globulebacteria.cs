using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome
{
	public class Globulebacteria : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Globulebacteria");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 64;
			npc.damage = 28;
			npc.defense = 9;
			npc.lifeMax = 41;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 75f;
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			animationType = 82;
			npc.noTileCollide = Main.hardMode;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 88;
            npc.damage = 56;
			npc.knockBackResist = 0.15f;
			if (Main.hardMode)
			{
				npc.lifeMax = 196;
				npc.damage = 94;
				npc.defense = 18;
				npc.knockBackResist = 0f;
			}
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
			if (npc.life <= 0)
			{
				if (Main.expertMode)
				{
					if (Main.rand.Next(2) == 0)
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
					if (Main.rand.Next(3) == 0)
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
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.7f : 0f;
		}
		
	    public override void NPCLoot()
        {
			if (Main.rand.Next(3) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
        }
	}
}