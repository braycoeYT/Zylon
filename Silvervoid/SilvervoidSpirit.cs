using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Silvervoid
{
	public class SilvervoidSpirit : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Silvervoid Spirit");
		}

        public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 24;
			npc.damage = 98;
			npc.defense = 38;
			npc.lifeMax = 2000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4000;
            npc.damage = 156;
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
		/*public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				player.AddBuff(BuffID.CursedInferno, 200, true);
			}
		}*/
		int Timer;
		float delay;
		public override void AI()
		{
			if (delay < 8)
				delay += 0.1f;
			//if (Main.player[npc.target].statLife < 1)
			//{
				npc.TargetClosest(true);
			//}
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 180 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 15f, mod.ProjectileType("SilvervoidPelletHostile"), 60, 1f, Main.myPlayer);
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * -delay;
			npc.rotation += 0.2f;
			for (int i = 0; i < 3; i++)
			{
				int dustType = 37;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	    public override void NPCLoot()
        {
	        Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"), Main.rand.Next(1, 3));
        }
	}
}