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
	public class PneumoniaPickaxe : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pneumonia Pickaxe");
		}
        public override void SetDefaults() {
			npc.width = 40;
			npc.height = 45;
			npc.damage = 209;
			npc.defense = 48;
			npc.lifeMax = 53000;
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
            npc.damage = 274;
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
					npc.rotation += 0.1f;
					if (attackMode == 0) {
						attackMode2 += 1;
						if (attackMode2 % 50 == 25)
						{
							Vector2 randomPos;
							randomPos.X = target.position.X + (Main.rand.Next(-200, 200));
							randomPos.Y = target.position.Y + (Main.rand.Next(-200, 200));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 3f, mod.ProjectileType("DiseaseOre"), 40, 10, Main.myPlayer);
							randomPos.X = target.position.X + (Main.rand.Next(-250, 250));
							randomPos.Y = target.position.Y + (Main.rand.Next(-250, 250));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 2f, mod.ProjectileType("DiseaseOre2"), 43, 10, Main.myPlayer);
							randomPos.X = target.position.X + (Main.rand.Next(-300, 300));
							randomPos.Y = target.position.Y + (Main.rand.Next(-300, 300));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 1f, mod.ProjectileType("DiseaseOre3"), 46, 10, Main.myPlayer);
						}
						if (attackMode2 > 300)
						attackDone = true;
					}
				}
				else if (attack == 2) {
					npc.rotation += 0.02f;
					npc.position.X = target.position.X;
					npc.position.Y = target.position.Y - 180;
					if (attackMode == 0) {
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ContagionSnakeTrailGood"), 45, 0, Main.myPlayer);
						attackMode2 += 1;
					}
					if (attackMode2 > 300)
						attackDone = true;
				}
			}
			else
			{
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
					npc.rotation = 0;
					if (attackMode == 0) {
						npc.position.X = target.position.X - 260;
						npc.position.Y = target.position.Y + 260;
						attackMode2 += 1;
						if (attackMode2 % 60 == 30)
						{
							Vector2 randomPos;
							randomPos.X = target.position.X + (Main.rand.Next(-200, 200));
							randomPos.Y = target.position.Y + (Main.rand.Next(-200, 200));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 1.3f, mod.ProjectileType("DiseaseOre"), 40, 10, Main.myPlayer);
							randomPos.X = target.position.X + (Main.rand.Next(-250, 250));
							randomPos.Y = target.position.Y + (Main.rand.Next(-250, 250));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 1.1f, mod.ProjectileType("DiseaseOre2"), 43, 10, Main.myPlayer);
							randomPos.X = target.position.X + (Main.rand.Next(-300, 300));
							randomPos.Y = target.position.Y + (Main.rand.Next(-300, 300));
							Projectile.NewProjectile(npc.Center, npc.DirectionTo(randomPos) * 0.9f, mod.ProjectileType("DiseaseOre3"), 46, 10, Main.myPlayer);
						}
						if (attackMode2 > 300)
						attackDone = true;
					}
				}
				else if (attack == 2) {
					npc.rotation = 215;
					npc.position.X = target.position.X;
					npc.position.Y = target.position.Y - 60;
					if (attackMode == 0) {
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ContagionSnakeTrailGood"), 45, 0, Main.myPlayer);
						attackMode2 += 1;
					}
					if (attackMode2 > 300)
						attackDone = true;
				}
			}
        }
	}
}