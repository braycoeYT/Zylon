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
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Minibosses
{
	[AutoloadBossHead]
	public class XenicAcidpumper : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenic Acidpumper");
			Main.npcFrameCount[npc.type] = 12;
		}

        public override void SetDefaults()
		{
			npc.width = 84;
			npc.height = 136;
			npc.damage = 160;
			npc.defense = 50;
			npc.lifeMax = 200000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 200000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.buffImmune[BuffID.Venom] = false;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 300000;
            npc.damage = 200;
        }
		public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		int flee = 0;
		int attack = 0;
		int timerUber = 0;
		int attackMax = 0;
		int attackNum = 0;
		int animationTimer;
		bool Chat1 = true;
		bool Uber1 = true;
		bool attackDone = true;
		Vector2 targetPlayer;
		public override void AI()
		{
			npc.TargetClosest(true);
			int gemCount = NPC.CountNPCS(mod.NPCType("AquaSapphire")) + NPC.CountNPCS(mod.NPCType("FlameGarnet")) + NPC.CountNPCS(mod.NPCType("SproutedEmerald"));
			int uberCount = NPC.CountNPCS(mod.NPCType("Ubercabochon"));
			Player target = Main.player[npc.target];
			targetPlayer = Main.player[npc.target].Center;
			
			Timer++;
			if (Timer % 3 == 0)
			{
				animationTimer++;
			}
			if (animationTimer > 11)
			animationTimer = 0;
			npc.frame.Y = animationTimer * 142;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
            }
			if (Timer % 120 < 60)
			npc.velocity.Y = 3;
			else
			npc.velocity.Y = -3;
			/*if (Main.expertMode) {
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 6);
					attackDone = false;
					attackMax = Main.rand.Next(2, 5);
					attackNum = 0;
				}
				if (attack == 1)
				{
					if (Main.rand.NextFloat() < .5f)
					{
						if (Timer % 110 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(5, 8);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), -6, mod.ProjectileType("Bloodbeat"), 40, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
					else
					{
						if (Timer % 110 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = 5;
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), 6, mod.ProjectileType("Bloodbeat"), 40, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
					if (Timer % 170 == 0)
					{
						if (Main.rand.NextFloat() < .5f)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(3, 6);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, Main.rand.Next(-4, 4), 468, 50, Main.myPlayer);
							}
						}
						else
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(3, 6);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6, Main.rand.Next(-4, 4), 468, 50, Main.myPlayer);
							}
						}
					}
				}
				else if (attack == 2)
				{
					if (Timer % 100 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadebloodOrb"), 75, 10, Main.myPlayer);
						if (1 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 3)
				{
					if (Timer % 15 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadowScythe"), 48, 10, Main.myPlayer);
						if (attackMax * 3 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 4)
				{
					if (Timer % 12 == 0)
					{
						if (Main.rand.NextFloat() < .5f)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-5, 5), Main.rand.Next(3, 8), mod.ProjectileType("Bloodpick"), 77, Main.myPlayer);
							if (attackMax * 3 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
						else
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-5, 5), Main.rand.Next(-8, -3), mod.ProjectileType("Bloodpick"), 77, Main.myPlayer);
							if (attackMax * 3 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
				else if (attack == 5)
				{
					if (Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("OmegaShadebloodOrb"), 85, 10, Main.myPlayer);
						if (attackMax < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
			}
			else 
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 5);
					attackDone = false;
					attackMax = Main.rand.Next(2, 5);
					attackNum = 0;
				}
				if (attack == 1)
				{
					if (Main.rand.NextFloat() < .5f)
					{
						if (Timer % 120 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = 5;
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), -6, mod.ProjectileType("Bloodbeat"), 41, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
					else
					{
						if (Timer % 120 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = 5;
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), 6, mod.ProjectileType("Bloodbeat"), 41, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
				else if (attack == 2)
				{
					if (Timer % 150 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadebloodOrb"), 80, 10, Main.myPlayer);
						if (-1 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 3)
				{
					if (Timer % 20 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadowScythe"), 41, 10, Main.myPlayer);
						if (attackMax * 3 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 4)
				{
					if (Timer % 18 == 0)
					{
						if (Main.rand.NextFloat() < .5f)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-4, 4), Main.rand.Next(1, 6), mod.ProjectileType("Bloodpick"), 60, Main.myPlayer);
							if (attackMax * 3 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
						else
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-4, 4), Main.rand.Next(-6, -1), mod.ProjectileType("Bloodpick"), 60, Main.myPlayer);
							if (attackMax * 3 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
			}*/
			//you can't dodge
			if (Main.expertMode)
			{
				if (npc.life > (int)(npc.lifeMax * 0.9f))
				{
					if (Timer % 60 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicCrystal"), 60, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.8f))
				{
					if (Timer % 60 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 60 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 60 == 45)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.7f))
				{
					if (Timer % 60 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 60 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 60 == 45)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.6f))
				{
					if (Timer % 60 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("ChargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 60 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 60 == 45)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.5f))
				{
					if (Timer % 120 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("ChargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 45 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 45 == 27)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.4f))
				{
					if (Timer % 120 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("ChargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 120 == 60)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicNucleus"), 60, 10, Main.myPlayer);
					if (Timer % 45 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 45 == 27)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.3f))
				{
					if (Timer % 120 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("SuperchargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 120 == 60)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicNucleus"), 60, 10, Main.myPlayer);
					if (Timer % 45 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 45 == 27)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.2f))
				{
					if (Timer % 120 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("SuperchargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 120 == 60)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicNucleus"), 60, 10, Main.myPlayer);
					if (Timer % 30 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
				}
				else if (npc.life > (int)(npc.lifeMax * 0.1f))
				{
					if (Timer % 120 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("SuperchargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 120 == 60)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicNucleus"), 60, 10, Main.myPlayer);
					if (Timer % 30 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("XenicAcidspit"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("XenicAcidspit"), 30, 10, Main.myPlayer);
				}
				else
				{
					if (Timer % 90 == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("SuperchargedXenicCrystal"), 60, 10, Main.myPlayer);
					if (Timer % 90 == 45)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 10, mod.ProjectileType("XenicNucleus"), 60, 10, Main.myPlayer);
					if (Timer % 30 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("ThinXenicCrystal"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 0)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y - 1000, 0, 5, mod.ProjectileType("XenicAcidspit"), 30, 10, Main.myPlayer);
					if (Timer % 30 == 15)
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-800, 801), npc.Center.Y + 1000, 0, -5, mod.ProjectileType("XenicAcidspit"), 30, 10, Main.myPlayer);
				}
			}
			else
			{

			}
			//you can't hide
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("XenicBattleRing"), 0, Main.myPlayer);
			//you can't run
			int playerCount;
			for (playerCount = 0; playerCount < 255; playerCount++) {
			if (Main.player[playerCount].active) {
				if (Vector2.Distance(npc.Center, Main.player[playerCount].Center) > 800 && Vector2.Distance(npc.Center, Main.player[playerCount].Center) < 1600)
					{
						Main.player[playerCount].KillMe(PlayerDeathReason.ByCustomReason(Main.player[playerCount].name + "'s mind melted."), 9999, 0, false);
					}
				}
			}
			//you can't target
			if (Main.dayTime)
			{
				if (Timer % 150 == 0 && gemCount < 12 && Main.expertMode)
				{
					int gemRand = Main.rand.Next(0, 3);
					if (gemRand == 0)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AquaSapphire"), 0, npc.whoAmI);
					}
					else if (gemRand == 1)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("FlameGarnet"), 0, npc.whoAmI);
					}
					else if (gemRand == 2)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("SproutedEmerald"), 0, npc.whoAmI);
					}
				}
			}
			else
			{
				if (Timer % 150 == 0 && uberCount < 12 && Main.expertMode)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Ubercabochon"), 0, npc.whoAmI);
			}
		}
		
	    public override void NPCLoot()
        {
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("XenicBag"));
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), 4 + Main.rand.Next(4));
				Item.NewItem(npc.getRect(), mod.ItemType("XenicCore"));
			}
			ZylonWorld.downedXenic = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 163;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
	}
}