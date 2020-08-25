using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.HM
{
	public class Ecolibacteria : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ecolibacteria");
		}

        public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 54;
			npc.damage = 71;
			npc.defense = 20;
			npc.lifeMax = 79;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 100f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 146;
            npc.damage = 132;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.expertMode)
			{
				target.AddBuff(BuffID.Weak, 960, false);
				target.AddBuff(mod.BuffType("Sick"), 1200, false);
			}
			else
			{
				target.AddBuff(BuffID.Weak, 480, false);
				target.AddBuff(mod.BuffType("Sick"), 600, false);
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
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int rand = Main.rand.Next(0, 600);
		Vector2 targetPos;
		public override void AI()
		{
			Timer++;
			targetPos = Main.player[npc.target].Center;
			if (Timer % 600 == rand)
			{
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("Ickyspit"), 20, 1f, Main.myPlayer);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode)
				return spawnInfo.player.GetModPlayer<ZylonPlayer>().ZoneMicrobiome && !spawnInfo.player.ZoneSkyHeight ? 0.12f : 0f;
			return 0f;
		}
		public override void NPCLoot()
        {
			if (Main.rand.Next(18) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
			//if (Main.rand.NextFloat() < .4f)
			//	Item.NewItem(npc.getRect(), mod.ItemType("Contagionite"));
		}
	}
}