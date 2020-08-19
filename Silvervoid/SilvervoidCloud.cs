using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Silvervoid
{
	public class SilvervoidCloud : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silvervoid Cloud");
		}

        public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 48;
			npc.damage = 87;
			npc.defense = 65535;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontCountMe = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 171;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SilvervoidCloud"));
			}
		}
		/*public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				player.AddBuff(BuffID.CursedInferno, 200, true);
			}
		}*/
		int Timer;
		int rand = Main.rand.Next(0, 2);
		public override void AI()
		{
			npc.life = npc.lifeMax;
			if (rand == 0)
			npc.velocity.X = -5;
			else
			npc.velocity.X = 5;
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			for (int i = 0; i < 1; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
					return (SpawnCondition.Crimson.Chance + SpawnCondition.Corruption.Chance) * 0.4f;
			return 0f;
        }
	}
}