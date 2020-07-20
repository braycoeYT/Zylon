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

namespace Zylon.NPCs.Minibosses
{
	[AutoloadBossHead]
	public class XenicAcidpumper : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenic Acidpumper");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 120;
			npc.damage = 160;
			npc.defense = 50;
			npc.lifeMax = 150000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 1000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 210000;
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
		bool Chat1 = true;
		bool Uber1 = true;
		bool attackDone = true;
		Vector2 targetPlayer;
		public override void AI()
		{
			npc.TargetClosest(true);
			targetPlayer = Main.player[npc.target].Center;
			
			Timer++;
			
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
		
			if (Uber1)
			{
				if (Chat1)
				{
				Color messageColor = Color.Pink;
					string chat = "A Xenic Acidpumper has landed nearby!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				timerUber++;
				if (timerUber % 5 == 1)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ubercabochon"), 0, npc.whoAmI);
				if (Main.expertMode) {
					if (timerUber > 45)
					{
						Uber1 = false;
						timerUber = 0;
					}
				}
				else {
					if (timerUber > 30)
					{
						Uber1 = false;
						timerUber = 0;
					}
				}
				Chat1 = false;
			}
			
			/*if (ZylonWorld.voidDream) {
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 6);
					attackDone = false;
					attackMax = Main.rand.Next(3, 6);
					attackNum = 0;
				}
				if (attack == 1)
				{
					if (Main.rand.NextFloat() < .5f)
					{
						if (Timer % 90 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(7, 11);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), -6, mod.ProjectileType("Bloodbeat"), 50, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
					else
					{
						if (Timer % 90 == 0)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(7, 11);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-4, 4), 6, mod.ProjectileType("Bloodbeat"), 50, Main.myPlayer);
							}
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
					if (Timer % 120 == 0)
					{
						if (Main.rand.NextFloat() < .5f)
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(4, 8);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, Main.rand.Next(-4, 4), 468, 60, Main.myPlayer);
							}
						}
						else
						{
							Main.PlaySound(SoundID.Item12);
							float numberProjectiles = Main.rand.Next(4, 8);
							for (int i = 0; i < numberProjectiles; i++)
							{
								Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6, Main.rand.Next(-4, 4), 468, 60, Main.myPlayer);
							}
						}
					}
				}
				else if (attack == 2)
				{
					if (Timer % 80 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadebloodOrb"), 85, 10, Main.myPlayer);
						if (1 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 3)
				{
					if (Timer % 10 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 4, mod.ProjectileType("ShadowScythe"), 51, 10, Main.myPlayer);
						if (attackMax * 4 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
				else if (attack == 4)
				{
					if (Timer % 6 == 0)
					{
						if (Main.rand.NextFloat() < .5f)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-7, 7), Main.rand.Next(5, 10), mod.ProjectileType("Bloodpick"), 81, Main.myPlayer);
							if (attackMax * 3 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
						else
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 1 + Main.rand.Next(-7, 7), Main.rand.Next(-10, -5), mod.ProjectileType("Bloodpick"), 81, Main.myPlayer);
							if (attackMax * 5 < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
				else if (attack == 5)
				{
					if (Timer % 20 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * Main.rand.Next(4, 8), mod.ProjectileType("OmegaShadebloodOrb"), 105, 10, Main.myPlayer);
						if (attackMax * 2 < attackNum)
						attackDone = true;
						attackNum += 1;
					}
				}
			}
			else*/ if (Main.expertMode) {
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
			}
		}
		
	    public override void NPCLoot()
        {
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("XenicBag"));
				if (!ZylonWorld.downedDiscus)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("XenicStory"));
				}
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), 4 + Main.rand.Next(4));
				if (ZylonWorld.downedXenic)
				Item.NewItem(npc.getRect(), mod.ItemType("XenicCore"));
			}
			ZylonWorld.downedXenic = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (!Main.dayTime)
			if (ZylonWorld.downedMineral)
			return SpawnCondition.Sky.Chance * 0.035f;
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