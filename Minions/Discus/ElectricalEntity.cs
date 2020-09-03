using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Minions.Discus
{
	public class ElectricalEntity : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Electrical Entity, Radias's loyal electroportal");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 80;
			npc.height = 80;
			npc.damage = 10;
			npc.defense = 9999;
			npc.lifeMax = 2000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.netAlways = true;
        }
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Electrified, 90, false);
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		Vector2 targetPlayer;
		public override void AI()
		{
			npc.TargetClosest(true);
			targetPlayer = Main.player[npc.target].Center;
			Timer++;
			npc.position.Y = targetPlayer.Y;
			npc.position.X = targetPlayer.X - 400;
			if (Timer % 200 == 60)
			{
				Main.PlaySound(SoundID.Item12);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -2, 0, ProjectileID.CultistBossLightningOrbArc, 20, 10, Main.myPlayer);
			}
			if (!NPC.AnyNPCs(NPCType<NPCs.Bosses.AncientDesertDiscus2>()))
				npc.life = 0;

			for (int i = 0; i < 10; i++)
			{
				int dustType = 226;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}