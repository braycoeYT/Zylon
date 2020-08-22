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
	public class BacteriumBlade : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bacterium Blade");
		}
        public override void SetDefaults() {
			npc.width = 44;
			npc.height = 44;
			npc.damage = 214;
			npc.defense = 46;
			npc.lifeMax = 98000;
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
            npc.lifeMax = 158000;
            npc.damage = 289;
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
		bool playerBadChat = true;
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
                if (flee >= 450)
                    npc.active = false;
				if (flee >= 100 && playerBadChat)
				{
					Color messageColor = Color.RoyalBlue;
					string chat = "Target neutralized.";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					playerBadChat = false;
				}
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
					if (attackMode == 0) {
						npc.rotation += 0.15f;
						attackMode2 += 1;
						if (attackMode2 > 180) {
							attackMode = 1;
							attackMode2 = 0;
						}
					}
					if (attackMode == 1)
					{
						npc.rotation = npc.velocity.Y * (float)npc.direction + 45 * 0.16f;
						npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)(-8.5f);
						attackMode2 += 1;
						if (attackMode2 > 180) {
							attackDone = true;
						}
					}
				}
				else if (attack == 2)
				{
					npc.rotation += 0.15f;
					if (attackMode == 0) {
						attackMode2 += 1;
						if (attackMode2 % 30 == 15) {
							Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FakeBacteriumBlade"), 75, 2, Main.myPlayer);
						}
						if (attackMode2 > 180) {
							attackDone = true;
						}
					}
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
					if (attackMode == 0) {
						npc.rotation += 0.15f;
						attackMode2 += 1;
						if (attackMode2 > 220) {
							attackMode = 1;
							attackMode2 = 0;
						}
					}
					if (attackMode == 1)
					{
						npc.rotation = npc.velocity.Y * (float)npc.direction + 45 * 0.16f;
						npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)(-8.5f);
						attackMode2 += 1;
						if (attackMode2 > 140) {
							attackDone = true;
						}
					}
				}
				else if (attack == 2)
				{
					npc.rotation += 0.15f;
					if (attackMode == 0) {
						attackMode2 += 1;
						if (attackMode2 % 45 == 15) {
							Projectile.NewProjectile(npc.Center, new Vector2(0, 3).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FakeBacteriumBlade"), 62, 2, Main.myPlayer);
						}
						if (attackMode2 > 180) {
							attackDone = true;
						}
					}
				}
			}
        }
	}
}