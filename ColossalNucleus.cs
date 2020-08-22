using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ColossalNucleus : ModNPC
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Colossal Nucleus");
		}

        public override void SetDefaults()
		{
			npc.width = 63;
			npc.height = 63;
			npc.damage = 21;
			npc.defense = 9;
			npc.lifeMax = 1109;
			npc.HitSound = SoundID.NPCHit9;
			npc.DeathSound = SoundID.NPCDeath11;
			npc.value = 50000f;
			npc.knockBackResist = 0.4f;
			npc.aiStyle = 85;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.lavaImmune = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CCell");
			npc.netAlways = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1998 + numPlayers * 240;
			npc.damage = 48;
			npc.knockBackResist = 0.3f;
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
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (Main.expertMode)
			{
				if (Main.rand.Next(16) == 0)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cell.BacteriteEgg>(), 0, npc.whoAmI);
			}
			else
			{
				if (Main.rand.Next(20) == 0)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cell.BacteriteEgg>(), 0, npc.whoAmI);
			}
		}
		int flee = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		int moveMode = 0;
		int Timer = 0;
		bool spawnStalkers = true;
		bool attackDone = true;
		Vector2 targetPos;
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.noTileCollide = true;
			Timer++;
			targetPos = Main.player[npc.target].Center;
			npc.dontTakeDamage = !Main.player[npc.target].GetModPlayer<ZylonPlayer>().ZoneMicrobiome;
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
				if (flee >= 450)
					npc.active = false;
			}

			if (Timer % 10 == 0)
			npc.rotation += 0.02f;
			/*if (spawnStalkers)
			{
				if (Main.expertMode)
				{
					for (int i = 0; i < 19; i++)
					{
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("Stalker"));
					}
				}
				else
				{
					for (int i = 0; i < 13; i++)
					{
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("Stalker"));
					}
				}
				spawnStalkers = false;
			}*/
			if (Main.expertMode)
			{
				if (Timer % 150 == 0)
				{
					if (Main.rand.Next(1, 3) == 1)
					{
						npc.position.X = targetPos.X + Main.rand.Next(100, 500);
					}
					else
					{
						npc.position.X = targetPos.X - Main.rand.Next(100, 500);
					}
					if (Main.rand.Next(1, 3) == 1)
					{
						npc.position.Y = targetPos.Y + Main.rand.Next(100, 500);
					}
					else
					{
						npc.position.Y = targetPos.Y - Main.rand.Next(100, 500);
					}
					for (int i = 0; i < 10; i++)
					{
						int dustType = 116;
						int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
						Dust dust = Main.dust[dustIndex];
						dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
						dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
						dust.scale *= 4f + Main.rand.Next(-30, 31) * 0.01f;
					}
				}

				//npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)-5.5;
			}
			else
			{
				if (Timer % 160 == 0)
				{
					if (Main.rand.Next(1, 3) == 1)
					{
						npc.position.X = targetPos.X + Main.rand.Next(100, 500);
					}
					else
					{
						npc.position.X = targetPos.X - Main.rand.Next(100, 500);
					}
					if (Main.rand.Next(1, 3) == 1)
					{
						npc.position.Y = targetPos.Y + Main.rand.Next(100, 500);
					}
					else
					{
						npc.position.Y = targetPos.Y - Main.rand.Next(100, 500);
					}
					for (int i = 0; i < 10; i++)
					{
						int dustType = 116;
						int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
						Dust dust = Main.dust[dustIndex];
						dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
						dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
						dust.scale *= 4f + Main.rand.Next(-30, 31) * 0.01f;
					}
				}

				//npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)-5;
			}
			if (Main.expertMode)
			{
				if (Timer % 20 == 0)
				{
					int randNum = Main.rand.Next(1, 4);
					if (randNum == 1)
					{
						Projectile.NewProjectile((int)targetPos.X + Main.rand.Next(-600, 600), (int)targetPos.Y - 600, 0, 2.5f, mod.ProjectileType("NavycellDebris"), 11, Main.myPlayer);
					}
					if (randNum == 2)
					{
						Projectile.NewProjectile((int)targetPos.X + Main.rand.Next(-600, 600), (int)targetPos.Y - 600, 0, 2.5f, mod.ProjectileType("NavycellDebris2"), 9, Main.myPlayer);
					}
					if (randNum == 3)
					{
						Projectile.NewProjectile((int)targetPos.X + Main.rand.Next(-600, 600), (int)targetPos.Y - 600, 0, 2.5f, mod.ProjectileType("NavycellDebris3"), 7, Main.myPlayer);
					}
				}
			}
		}
	    public override void NPCLoot()
        {
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("CellBag"));
			}
		    else
			{
			    Item.NewItem(npc.getRect(), mod.ItemType("TwistedMembraneOre"), Main.rand.Next(55, 106));
				Item.NewItem(npc.getRect(), mod.ItemType("Cytoplasm"), Main.rand.Next(37, 58));
			}
			ZylonWorld.downedCell = true;
        }
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "Colossal Cell";
		}
	}
}