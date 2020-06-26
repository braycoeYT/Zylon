using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.HM
{
	public class FloatingRockeater : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Floating Rockeater");
		}

        public override void SetDefaults()
		{
			npc.width = 14;
			npc.height = 14;
			npc.damage = 80;
			npc.defense = 18;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 1000f;
			npc.knockBackResist = 0.4f;
			npc.aiStyle = 23;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 400;
            npc.damage = 160;
			npc.knockBackResist = 0.36f;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 80;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(0, 4) == 0)
			if (Main.expertMode)
			{
				target.AddBuff(BuffID.Cursed, 480, false);
			}
			else
			{
				target.AddBuff(BuffID.Cursed, 240, false);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.player.ZoneDirtLayerHeight || spawnInfo.player.ZoneRockLayerHeight)
			if (Main.hardMode)
			return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome ? 0.06f : 0f;
			return 0f;
		}
		public override void NPCLoot()
        {
			if (Main.rand.NextFloat() < .01f)
				Item.NewItem(npc.getRect(), ItemID.Nazar);
        }
	}
}