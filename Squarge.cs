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
			Main.npcFrameCount[npc.type] = 2;
		}
		
        public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 69;
			npc.defense = 25;
			npc.lifeMax = 2100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 568f;
			npc.aiStyle = 2;
			npc.knockBackResist = 0f;
			animationType = 1;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4200;
            npc.damage = 138;
			npc.defense = 35;
        }
		public float Timer
		{
	        get => npc.ai[1];
	        set => npc.ai[1] = value;
        }
		public override void AI()
		{
			Timer++;
			if (Main.expertMode)
			{
				if (Timer % 120 == 0)
				{
					Main.PlaySound(SoundID.Item12);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 6, 96, 30, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -6, 96, 25, Main.myPlayer);
				}
			}
			else
			{
				if (Timer % 150 == 0)
				{
					Main.PlaySound(SoundID.Item12);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 6, 96, 25, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -6, 96, 25, Main.myPlayer);
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
	        Item.NewItem(npc.getRect(), 2766);
        }
	}
}