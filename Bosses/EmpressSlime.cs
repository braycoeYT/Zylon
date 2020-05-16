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
using Zylon.Items;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class EmpressSlime : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Empress Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

        public override void SetDefaults()
		{
			npc.width = 165;
			npc.height = 160;
			npc.damage = 61;
			npc.defense = 41;
			npc.lifeMax = 35000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 150000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1; //51 original
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.boss = true;
			npc.lavaImmune = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			animationType = 1;
			npc.alpha = 50;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 48000 + numPlayers * 8000;
			npc.damage = 120;
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
			if (npc.lifeMax / 2 < npc.life)
			{
				if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Empress.RoyalMotherSlime>(), 0, npc.whoAmI);
			}
			else
			{
				if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Empress.RoyalSlimer>(), 0, npc.whoAmI);
			}

			for (int i = 0; i < 10; i++)
			{
				int dustType = 266;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
		int flee = 0;
		int rage = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		bool attackDone = true;
		Vector2 targetPos;

		public override void AI()
		{
			Timer++;
			if (npc.lifeMax / 2 > npc.life)
			{
				npc.aiStyle = 2;
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (Main.expertMode)
				{
					int healSpeed = (int)(npc.life / 400);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
				else
				{
					int healSpeed = (int)(npc.life / 500);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
			}
			else
			{
				npc.aiStyle = 1;
				npc.noGravity = false;
				npc.noTileCollide = false;
			}
			if (npc.lifeMax / 2 < npc.life)
			{
				rage += 1;
				if (rage > 600)
				{
					npc.position.X = Main.player[npc.target].position.X - Main.rand.Next(-500, 501);
					npc.position.Y = Main.player[npc.target].position.Y - 600;
					rage = 0;
				}
			}

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
			
			
			targetPos = Main.player[npc.target].Center;

			if (Main.expertMode)
			{
				if (Timer % 400 == 0)
				{
					float numberNPC = Main.rand.Next(3, 6);
					for (int i = 0; i < numberNPC; i++)
					{
						Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
					}
				}
			}
			else
			{
				if (Timer % 520 == 0)
				{
					float numberNPC = Main.rand.Next(2, 5);
					for (int i = 0; i < numberNPC; i++)
					{
						Main.PlaySound(SoundID.Item116.WithPitchVariance(2f));
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
					}
				}
			}

			if (Timer % 600 == 0)
			{
				float numberProjectiles = 50;
				int delay = 0;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(npc.Center.X - 3750 + delay, npc.Center.Y - 750, 0, 2, mod.ProjectileType("EmpressBlob"), 26, Main.myPlayer);
					delay += 150;
				}
			}

			if (Main.expertMode)
			{
				if (attackDone)
				{
					attack = Main.rand.Next(1, 4);
					attackDone = false;
					attackMax = Main.rand.Next(3, 7);
					attackNum = 0;
				}
				if (npc.lifeMax / 2 < npc.life)
				{
					if (attack == 1 && Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("EmpressGlob"), 24, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 120 == 0)
					{
						float numberProjectiles = Main.rand.Next(5, 10);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 32, 2, Main.myPlayer);
							if (attackMax < attackNum)
								attackDone = true;
							attackNum += 1;
						}
					}
					if (attack == 3 && Timer % 120 == 0)
					{
						float numberProjectiles = Main.rand.Next(15, 26);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressSpike"), 28, 2, Main.myPlayer);
						}
						attackDone = true;
					}
				}
				else
				{
					if (attack == 1 && Timer % 50 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 5, mod.ProjectileType("EmpressGlob"), 25, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 100 == 0)
					{
						float numberProjectiles = Main.rand.Next(6, 11);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(1, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 33, 2, Main.myPlayer);
							if (attackMax < attackNum)
								attackDone = true;
							attackNum += 1;
						}
					}
					if (attack == 3 && Timer % 100 == 0)
					{
						float numberProjectiles = Main.rand.Next(26, 41);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(1, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressSpike"), 29, 2, Main.myPlayer);
						}
						attackDone = true;
					}
				}
			}
			else
			{
				if (attackDone)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = Main.rand.Next(3, 6);
					attackNum = 0;
				}
				if (npc.lifeMax / 2 < npc.life)
				{
					if (attack == 1 && Timer % 70 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 3, mod.ProjectileType("EmpressGlob"), 29, 10, Main.myPlayer);
						if (attackMax < attackNum)
						attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 140 == 0)
					{
						float numberProjectiles = Main.rand.Next(5, 10);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 38, 2, Main.myPlayer);
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
				else
				{
					if (attack == 1 && Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("EmpressGlob"), 29, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 120 == 0)
					{
						float numberProjectiles = Main.rand.Next(6, 11);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 38, 2, Main.myPlayer);
							if (attackMax < attackNum)
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
				Item.NewItem(npc.getRect(), mod.ItemType("EmpressBag"));
				if (!WorldEdit.downedEmpress)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("EmpressStory"));
				}
			}
			else
			{
				int ran = Main.rand.Next(1, 7);
				if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("EmpressYolk"));
				if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("EmpressBleeders"));
				if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("Egg"));
				if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("EmpressShuriken"));
				if (ran == 5) Item.NewItem(npc.getRect(), mod.ItemType("Telomere"));
				if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("EmpressTears"));

				Item.NewItem(npc.getRect(), mod.ItemType("EmpressShard"), Main.rand.Next(9, 15));
			}
			WorldEdit.downedEmpress = true;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.GreaterHealingPotion;
		}
	}
}