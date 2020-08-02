using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome
{
	public class Virobacter : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Virobacter");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 62;
			npc.height = 34;
			npc.damage = 16;
			npc.defense = 4;
			npc.lifeMax = 41;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 80f;
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 39;
			animationType = 82;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 88;
            npc.damage = 31;
			npc.knockBackResist = 0.1f;
			if (Main.hardMode)
			{
				npc.lifeMax = 196;
				npc.damage = 56;
				npc.defense = 9;
				npc.knockBackResist = 0f;
			}
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 92;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.12f : 0f;
		}
		
	    public override void NPCLoot()
        {
			if (Main.rand.Next(3) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
        }
	}
}