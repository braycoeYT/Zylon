using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome
{
	public class Cyanixobacteria : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cyanixobacteria");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 44;
			npc.damage = 28;
			npc.defense = 10;
			npc.lifeMax = 48;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 110f;
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			animationType = 82;
			npc.noTileCollide = Main.hardMode;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 93;
            npc.damage = 56;
			npc.knockBackResist = 0.1f;
			if (Main.hardMode)
			{
				npc.lifeMax = 201;
				npc.damage = 94;
				npc.defense = 21;
				npc.knockBackResist = 0f;
			}
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 34;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.15f : 0f;
		}
		
	    public override void NPCLoot()
        {
			if (Main.rand.Next(3) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
			Item.NewItem(npc.getRect(), mod.ItemType("CyanixOre"), Main.rand.Next(2, 7));
		}
	}
}