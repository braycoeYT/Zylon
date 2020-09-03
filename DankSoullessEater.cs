using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class DankSoullessEater : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Darkness Chaser");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 65;
			npc.height = 40;
			npc.damage = 156;
			npc.defense = 38;
			npc.lifeMax = 2100;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 399f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 10;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3945;
            npc.damage = 219;
			npc.defense = 41;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 71;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				player.AddBuff(BuffID.CursedInferno, 200, true);
			}
		}
		int Timer;
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
			}
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 120 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 2.5f, ProjectileID.ShadowBeamHostile, 59, 1f, Main.myPlayer);
		}
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Corruption.Chance * 0.1f;
			}
			return 0f;
        }*/
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
	        Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
        }
	}
}