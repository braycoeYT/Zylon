using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Silvervoid
{
	public class SilvervoidKamikazeDead : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silvervoid Kamikaze");
		}

        public override void SetDefaults()
		{
			npc.width = 48;
			npc.height = 48;
			npc.damage = 100;
			npc.defense = 0;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 100f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			npc.dontTakeDamage = true;
			npc.trapImmune = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 200;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Main.PlaySound(SoundID.Item62);
				Projectile.NewProjectile(npc.Center, new Vector2(0, 0), mod.ProjectileType("SilvervoidKamikazeNuke"), npc.damage, 2, Main.myPlayer);
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
		float Speed;
		public override void AI()
		{
			Speed += 0.02f;
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer > 480)
			npc.life = 0;
			if (Timer == 479)
			{
				Main.PlaySound(SoundID.Item62);
				Projectile.NewProjectile(npc.Center, new Vector2(0, 0), mod.ProjectileType("SilvervoidKamikazeNuke"), (int)(npc.damage * 1.1), 2, Main.myPlayer);
				if ((Main.rand.Next(0, 7) == 0 && Main.expertMode) || (Main.rand.Next(0, 8) == 0 && !Main.expertMode))
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SilvervoidSpirit"));
			}
			for (int i = 0; i < 3; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * -Speed;
			npc.rotation += 0.01f * Speed;
		}
	}
}