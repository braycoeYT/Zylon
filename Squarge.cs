using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.NPCs
{
	public class Squarge : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Squarge");
			Main.npcFrameCount[npc.type] = 3;
		}
		
        public override void SetDefaults()
		{
			npc.width = 46;
			npc.height = 48;
			npc.damage = 69;
			npc.defense = 25;
			npc.lifeMax = 2100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 250f;
			npc.aiStyle = 2;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4200;
            npc.damage = 138;
			npc.defense = 35;
        }
		int Timer;
		int animationTimer;
		public override void AI()
		{
			Timer++;
			if (Timer % 3 == 0)
			{
				animationTimer++;
			}
			if (animationTimer > 2)
			animationTimer = 0;
			npc.frame.Y = animationTimer * 48;
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			if (Main.expertMode)
			{
				if (Timer % 120 == 0)
				{
					Main.PlaySound(SoundID.Item12);
					Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 12, mod.ProjectileType("SquargeSpitHostile"), 30, 1f, Main.myPlayer);
				}
			}
			else
			{
				if (Timer % 150 == 0)
				{
					Main.PlaySound(SoundID.Item12);
					Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 10, mod.ProjectileType("SquargeSpitHostile"), 30, 1f, Main.myPlayer);
				}
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedGolemBoss)
			return SpawnCondition.Sky.Chance * 0.1f;
			return 0f;
        }
		
	    public override void NPCLoot()
        {
			if (Main.rand.NextFloat() < .3f)
	        Item.NewItem(npc.getRect(), ItemID.LunarTabletFragment);
			if (Main.rand.NextFloat() < .01f)
	        Item.NewItem(npc.getRect(), mod.ItemType("SquargeSpitStaff"));
			if (Main.rand.NextFloat() < .005f)
	        Item.NewItem(npc.getRect(), mod.ItemType("VenomousPill"));
			if (Main.rand.NextFloat() < .005f)
	        Item.NewItem(npc.getRect(), ItemID.Vitamins);
        }
	}
}