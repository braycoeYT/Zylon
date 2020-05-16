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
	public class Dirtball : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirtball");
		}

        public override void SetDefaults()
		{
			npc.width = 150;
			npc.height = 144;
			npc.damage = 11;
			npc.defense = 1;
			npc.lifeMax = 850;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 590f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.lavaImmune = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1320;
            npc.damage = 25;
			npc.defense = 2;
			npc.buffImmune[BuffID.Slow] = true;
        }
		public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		int flee = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		int dirtSpawn = 0;
		bool attackDone = true;
		Vector2 targetPlayer;
		public override void AI()
		{
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)-2;
			
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
			
			/*if (WorldEdit.voidDream)
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = 3;
					attackNum = 0;
					dirtSpawn = Main.rand.Next(1, 3);
				}
				
				if (attack == 1)
				{
					if (Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 3, mod.ProjectileType("DirtBall"), 6, 10, Main.myPlayer);
						if (attackMax < attackNum + 1)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
				else if (attack == 2)
				{
					if (Timer % 150 == 0)
					{
						float numberProjectiles = Main.rand.Next(2, 7);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 200, Main.rand.Next(-7, 7), -3, mod.ProjectileType("DirtBall2"), 5, Main.myPlayer);
						}
						attackDone = true;
						attackNum += 1;
					}
				}
			}*/
			else if (Main.expertMode)
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = 3;
					attackNum = 0;
					dirtSpawn = Main.rand.Next(1, 3);
				}
				
				if (attack == 1)
				{
					if (Timer % 75 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 3, mod.ProjectileType("DirtBall"), 5, 10, Main.myPlayer);
						if (attackMax < attackNum + 1)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
				else if (attack == 2)
				{
					if (Timer % 150 == 0)
					{
						float numberProjectiles = Main.rand.Next(2, 6);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 200, Main.rand.Next(-7, 7), -3, mod.ProjectileType("DirtBall2"), 4, Main.myPlayer);
						}
						attackDone = true;
						attackNum += 1;
					}
				}
			}
			else
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = 3;
					attackNum = 0;
					dirtSpawn = Main.rand.Next(1, 3);
				}
				
				if (attack == 1)
				{
					if (Timer % 90 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 3, mod.ProjectileType("DirtBall"), 4, 10, Main.myPlayer);
						if (attackMax < attackNum + 1)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
				else if (attack == 2)
				{
					if (Timer % 150 == 0)
					{
						float numberProjectiles = Main.rand.Next(1, 6);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 200, Main.rand.Next(-7, 7), -3, mod.ProjectileType("DirtBall2"), 3, Main.myPlayer);
						}
						attackDone = true;
						attackNum += 1;
					}
				}
			}
		}
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DirtballBag"));
				if (!WorldEdit.downedDirtball)
				{
					Item.NewItem(npc.getRect(), mod.ItemType("DirtballStory"));
				}
			}
		    else
			{
			int ran = Main.rand.Next(1, 8);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtyDiscus"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtyHarp"));
			if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("DirtyPistol"));
			if (ran == 5) Item.NewItem(npc.getRect(), mod.ItemType("DirtyJar"));
			if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("DirtYoyo"));
			if (ran == 7) Item.NewItem(npc.getRect(), mod.ItemType("DirtBow"));
			
			ran = Main.rand.Next(1, 4);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("DirtballHelmet"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtballGuardplate"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtballLeggings"));
			
			Item.NewItem(npc.getRect(), ItemID.CopperBar, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.DirtBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.MudBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Lens, 1 + Main.rand.Next(1));
			
			if (Main.rand.NextFloat() < .5f)
			Item.NewItem(npc.getRect(), mod.ItemType("DirtyMedal"));
			}
			
			WorldEdit.downedDirtball = true;
        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (!WorldEdit.downedDirtball)
			{
				if(Main.dayTime)
			    return 0.00075f;
			}
			return 0f;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.expertMode)
			{
			    if (Main.rand.Next(105) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RedSlime, 0, npc.whoAmI);
			    if (Main.rand.Next(80) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BlueSlime, 0, npc.whoAmI);
			    if (Main.rand.Next(65) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GreenSlime, 0, npc.whoAmI);
			}
			
			if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GreenSlime, 0, npc.whoAmI);
		}
	}
}