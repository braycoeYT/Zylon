using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Microbiome.HM
{
	public class Targeton : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Targeton");
		}

        public override void SetDefaults()
		{
			npc.width = 46;
			npc.height = 46;
			npc.damage = 61;
			npc.defense = 20;
			npc.lifeMax = 136;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 100f;
			npc.knockBackResist = 0.05f;
			npc.aiStyle = 5;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.EaterofSouls;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 259;
            npc.damage = 124;
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
		int rand = Main.rand.Next(0, 180);
		Vector2 targetPos;
		public override void AI()
		{
			Timer++;
			targetPos = Main.player[npc.target].Center;
			if (Timer % 180 == rand)
			{
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 7, mod.ProjectileType("Ickyspit"), 20, 1f, Main.myPlayer);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode)
				return ZylonWorld.microbiomeTiles > 140 && spawnInfo.player.ZoneSkyHeight ? 0.23f : 0f;
			return 0f;
		}
		public override void NPCLoot()
        {
			if (Main.rand.Next(18) == 0)
			Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
			if (Main.rand.NextFloat() < .15f)
			Item.NewItem(npc.getRect(), mod.ItemType("InfectedBlood"));
		}
	}
}