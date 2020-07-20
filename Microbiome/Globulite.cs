using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome
{
	public class Globulite : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Globulite");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 16;
			npc.damage = 7;
			npc.defense = 12;
			npc.lifeMax = 19;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 4f;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			animationType = 82;
			npc.noTileCollide = Main.hardMode;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 29;
            npc.damage = 9;
			npc.knockBackResist = 1f;
			if (Main.hardMode)
			{
				npc.lifeMax = 72;
				npc.damage = 36;
				npc.defense = 41;
				npc.knockBackResist = 1.2f;
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
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int rand = Main.rand.Next(250, 601);
		float moveX = Main.rand.NextFloat(-2, 2);
		float moveY = Main.rand.NextFloat(-2, 2);
		public override void AI()
		{
			Timer++;
			if (Timer > rand)
			{
				npc.life = 0;
				Timer = 0;
				NPC.NewNPC((int)npc.position.X + Main.rand.Next(-25, 25), (int)npc.position.Y + Main.rand.Next(-25, 25), mod.NPCType("Globulebacteria2"));
			}
			npc.velocity.X = moveX;
			npc.velocity.Y = moveY;
			if (Timer % 20 == 0)
            {
				npc.velocity.X = npc.velocity.X / 2;
				npc.velocity.Y = npc.velocity.Y / 2;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.12f : 0f;
		}
		public override void NPCLoot()
        {
			if (Main.rand.Next(9) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
        }
	}
}