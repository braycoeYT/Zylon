using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Silvervoid
{
	public class SilvervoidSoldier : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silvervoid Soldier");
			Main.npcFrameCount[npc.type] = 3;
		}

        public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 38;
			npc.damage = 151;
			npc.defense = 17;
			npc.lifeMax = 1908;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 100f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 3;
			npc.noGravity = false;
			npc.noTileCollide = false;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3816;
            npc.damage = 259;
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
				if ((Main.rand.Next(0, 7) == 0 && Main.expertMode) || (Main.rand.Next(0, 8) == 0 && !Main.expertMode))
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SilvervoidSpirit"));
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
		int animationTimer;
		public override void AI()
		{
			Timer++;
			if (Timer % 3 == 0)
			{
				animationTimer++;
			}
			if (animationTimer > 2)
			animationTimer = 0;
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			npc.spriteDirection = npc.direction;
			npc.frame.Y = animationTimer * 38;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
					return (SpawnCondition.Crimson.Chance + SpawnCondition.Corruption.Chance) * 0.3f;
			return 0f;
        }
	}
}