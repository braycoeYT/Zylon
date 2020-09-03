using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ContagionexTools
{
	[AutoloadBossHead]
	public class PneumoniaPickaxe : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pneumonia Pickaxe");
		}
        public override void SetDefaults() {
			npc.width = 38;
			npc.height = 38;
			npc.damage = 234;
			npc.defense = 31;
			npc.lifeMax = 43375;
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
			npc.buffImmune[BuffID.CursedInferno] = false;
			npc.buffImmune[BuffID.Ichor] = false;
			npc.alpha = 255;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 62625;
            npc.damage = 189;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			player.AddBuff(mod.BuffType("Sick"), 600, true);
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = mod.DustType("ContagionexToolsDust");
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
		bool playerBadChat = true;
		int Timer;
		int flee;
        public override void AI() {
			Timer++;
			Player target = Main.player[npc.target];
			if (Timer > 600)
			npc.dontTakeDamage = !Main.player[npc.target].GetModPlayer<ZylonPlayer>().ZoneMicrobiome;
			else
			npc.dontTakeDamage = true;
			npc.TargetClosest(true);
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
                if (flee >= 300)
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
			//start
			if (Timer < 600)
			{
				if (Timer < 480)
				npc.position = new Vector2(target.position.X + 200, target.position.Y - 200);
				if (Timer > 80 && npc.alpha != 0)
					npc.alpha--;
			}
			//attack
			else
			{
				if (npc.ai[0] == 0f)
				{
					float num320 = 9f;
					Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num321 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
					float num322 = Main.player[npc.target].position.Y - 400 + (float)(Main.player[npc.target].height / 2) - vector36.Y;
					float num323 = (float)Math.Sqrt((double)(num321 * num321 + num322 * num322));
					num323 = num320 / num323;
					num321 *= num323;
					num322 *= num323;
					if (Vector2.Distance(npc.Center, target.Center) > 2000)
					{
						npc.velocity.X = num321 * 6f; //speed?
						npc.velocity.Y = num322 * 6f; //speed?
					}
					else if (Vector2.Distance(npc.Center, target.Center) > 1000 || npc.life < npc.lifeMax / 2)
					{
						npc.velocity.X = num321 * 2f; //speed?
						npc.velocity.Y = num322 * 2f; //speed?
					}
					else
					{
						npc.velocity.X = num321 * 1.25f; //speed?
						npc.velocity.Y = num322 * 1.25f; //speed?
					}
					
					npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
					npc.ai[0] = 1f;
					npc.ai[1] = 0f;
					npc.netUpdate = true;
					return;
				}
				if (npc.ai[0] == 1f)
				{
					/*if (npc.justHit)
					{
						npc.ai[0] = 2f;
						npc.ai[1] = 0f;
					}*/
					if (npc.ai[1] == 0)
					{
						//for (int i = 0; i < Main.rand.Next(2, 6); i++)
						//{
						Projectile.NewProjectile(npc.Center, new Vector2(0, Main.rand.Next(2, 8)).RotatedBy((Math.PI / 180) * Main.rand.Next(-179, 180), default), mod.ProjectileType("DiseaseOre"), 60, 1f, Main.myPlayer);
						Projectile.NewProjectile(npc.Center, new Vector2(0, Main.rand.Next(2, 7)).RotatedBy((Math.PI / 180) * Main.rand.Next(-179, 180), default), mod.ProjectileType("DiseaseOre2"), 65, 1f, Main.myPlayer);
						Projectile.NewProjectile(npc.Center, new Vector2(0, Main.rand.Next(2, 6)).RotatedBy((Math.PI / 180) * Main.rand.Next(-179, 180), default), mod.ProjectileType("DiseaseOre3"), 70, 1f, Main.myPlayer);
						//}
					} //change
					npc.velocity *= 0.99f;
					npc.ai[1] += 2f; //spin length?
					if (npc.ai[1] >= 100f)
					{
						npc.netUpdate = true;
						npc.ai[0] = 2f;
						npc.ai[1] = 0f;
						npc.velocity.X = 0f;
						npc.velocity.Y = 0f;
						return;
						}
					}
					else
					{
						/*if (npc.justHit)
						{
							npc.ai[0] = 2f;
							npc.ai[1] = 0f;
						}*/
						if (npc.ai[1] % 30 == 0)
						Projectile.NewProjectile(npc.Center, new Vector2(0, 15).RotatedBy((Math.PI / 180) * Main.rand.Next(-179, 180), default), mod.ProjectileType("TocPneumoniaPickaxeFake"), 90, 1f, Main.myPlayer);
						npc.velocity *= 0.96f;
						npc.ai[1] += 1f;
						float num324 = npc.ai[1] / 120f;
						num324 = 0.1f + num324 * 0.4f;
						npc.rotation += num324 * (float)npc.direction;
						//if (npc.ai[1] >= 120f) //120
						//{
							npc.netUpdate = true;
							npc.ai[0] = 0f;
							npc.ai[1] = 0f;
							return;
						//}
					}
			}
			if (Vector2.Distance(npc.Center, target.Center) > 2000)
			{

			}
			int playerCount;
			for (playerCount = 0; playerCount < 255; playerCount++) {
			if (Main.player[playerCount].active) {
				if (Vector2.Distance(npc.Center, Main.player[playerCount].Center) < 7500)
					{
						Main.player[playerCount].AddBuff(mod.BuffType("WingsBadToolsContagion"), 5, false);
					}
				}
			}
        }
	}
}