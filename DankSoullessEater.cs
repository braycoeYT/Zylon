using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class DankSoullessEater : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Darkness Chaser");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.width = 65;
			npc.height = 40;
			npc.damage = 156;
			npc.defense = 38;
			npc.lifeMax = 2100;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = 399f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 10;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 3945;
            npc.damage = 289;
			npc.defense = 41;
        }
		
		public float Timer
		{
	        get => npc.ai[1];
	        set => npc.ai[1] = value;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 71;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		
		/*public override void AI()
		{
			Timer++;
			
			if (Main.expertMode)
			{
				if (ZylonWorld.voidDream)
				{
					if (Timer % 100 == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(-1f, 1f), -5f, ProjectileType<Projectiles.NightDaggerHostile>(), 0, 0, Main.myPlayer);
					}
				}
				else
				{
					if (Timer % 140 == 0)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(-1f, 1f), -5f, ProjectileType<Projectiles.NightDaggerHostile>(), 0, 0, Main.myPlayer);
					}
				}
			}
			else
			{
				if (Timer % 180 == 0)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.NextFloat(-1f, 1f), -5f, ProjectileType<Projectiles.NightDaggerHostile>(), 0, 0, Main.myPlayer);
				}
			}
			
			if (Timer > 180)
			Timer = 0;
		}*/
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (NPC.downedMoonlord)
			{
			    return SpawnCondition.Corruption.Chance * 0.1f;
			}
			return 0f;
        }
		
	    public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 0)
	        Item.NewItem(npc.getRect(), mod.ItemType("DarkSoul"));
        }
	}
}