using Zylon;
using Zylon.Items;
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

namespace Zylon.NPCs.Bosses.ContagionTools
{
	[AutoloadBossHead]
	public class AntraxAxe : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Antrax Axe");
		}
        public override void SetDefaults() {
			npc.width = 40;
			npc.height = 45;
			npc.damage = 221;
			npc.defense = 42;
			npc.lifeMax = 52000;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 91000;
            npc.damage = 293;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Sick"), 240, true);
			}
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
				dust.scale *= 1f + Main.rand.Next(-35, 36) * 0.01f;
			}
			if (npc.life <= 0)
			{
				npc.boss = false;
				//NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("AncientDesertDiscus2"));
			}
		}
		bool attackDone = true;
		bool startTeleport = true;
		int Timer;
		int flee;
		int RageTimer;
		int attack;
		int attackMode;
		int attackMode2;
		Vector2 target2;
        public override void AI() {
			if (!Main.player[npc.target].GetModPlayer<ZylonPlayer>().ZoneMicrobiome)
			{
				RageTimer++;

				if (RageTimer > 119)
					npc.dontTakeDamage = true;
				else
					npc.dontTakeDamage = false;
			}
			if (Main.player[npc.target].GetModPlayer<ZylonPlayer>().ZoneMicrobiome)
				RageTimer = 0;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
						flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1)
			{
				flee++;
				npc.noTileCollide = true;
				if (flee >= 350)
					npc.active = false;
			}
			Timer++;
			if (startTeleport) {
				if (Main.rand.NextBool()) {
					npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 500);
				}
				else {
					npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(-500, -200);
				}
				if (Main.rand.NextBool()) {
					npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 500);
				}
				else {
					npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-500, -200);
				}
				startTeleport = false;
			}
			Player target = Main.player[npc.target];
			npc.TargetClosest(true);
			if (Main.expertMode) {
				if (attackDone == true) {
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMode = 0;
					attackMode2 = 0;
					npc.rotation = 0;
					npc.velocity.X = 0;
					npc.velocity.Y = 0;
					if (Main.rand.NextBool())
					{
						npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 500);
					}
					else
					{
						npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(-500, -200);
					}

					if (Main.rand.NextBool())
					{
						npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 500);
					}
					else
					{
						npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-500, -200);
					}
				}
				if (attack == 1) {
					npc.rotation += 0.13f;
					attackMode2 += 1;
					Vector2 target2 = target.position;
					target2.X += Main.rand.Next(-350, 351);
					target2.Y += Main.rand.Next(-350, 351);
					if (attackMode2 % 45 == 0)
						Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 1, mod.ProjectileType("AntraxAxeThrow"), 42, 1f, Main.myPlayer);
					if (attackMode2 > 225)
						attackDone = true;
					}
				else if (attack == 2) {
					if (attackMode % 2 == 0) {
						target2.X = target.position.X;
						target2.Y = target.position.Y;
						attackMode += 1;
						attackMode2 = 0;
					}
					if (attackMode % 2 == 1) {
						npc.rotation += 0.13f;
						if (attackMode2 < 61)
						npc.velocity = Vector2.Normalize(npc.Center - target2) * (float)(-8.5f);
						attackMode2 += 1;
						if (attackMode2 > 90)
							attackMode += 1;
					}
					if (attackMode > 6)
					attackDone = true;
				}
			}
			else
			{

			}
        }
	}
}