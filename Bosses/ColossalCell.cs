using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ColossalCell : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Colossal Cell");
		}
        public override void SetDefaults()
		{
			npc.width = 148;
			npc.height = 148;
			npc.damage = 32;
			npc.defense = 6;
			npc.lifeMax = 3142;
			npc.HitSound = SoundID.NPCHit9;
			npc.DeathSound = SoundID.NPCDeath11;
			npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
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
			npc.buffImmune[mod.BuffType("Sick")] = true;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 4593 + numPlayers * 800;
			npc.damage = 56;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 40;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0)
			{
				npc.boss = false;
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ColossalNucleus"));
			}
			if (Main.expertMode)
				if (Main.rand.Next(25) == 0)
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cell.Bacterite>(), 0, npc.whoAmI);
				else
			if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.Cell.Bacterite>(), 0, npc.whoAmI);
		}
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		public float RageTimer
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}
		int flee = 0;
		int attack = 0;
		int moveMode2 = 0;
		int moveMode = 0;
		bool attackDone = true;
		public override void AI()
		{
			Player target = Main.player[npc.target];
			Timer++;
			if (!Main.player[npc.target].GetModPlayer<ZylonPlayer>().ZoneMicrobiome)
			{
				RageTimer++;

				if (RageTimer > 299)
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
				if (flee >= 450)
					npc.active = false;
			}
			if (Timer < 100)
			npc.TargetClosest(true);
			if (moveMode2 == 0)
			{
				if (npc.position.Y < target.position.Y - 400)
				{
					//if (Timer % 20 == 0)
						npc.velocity.Y += 1;

					//if (npc.velocity.Y < 0)
					//	npc.velocity.Y = 3;
				}
				else //if (npc.position.Y > target.position.Y - 400)
				{
					//if (Timer % 20 == 0)
						npc.velocity.Y -= 1;

					//if (npc.velocity.Y > 0)
					//	npc.velocity.Y = -3;
				}
			}
			else if (moveMode2 == 1)
			{
				if (npc.position.Y < target.position.Y + 180)
				{
					//if (Timer % 20 == 0)
						npc.velocity.Y += 1;

					//if (npc.velocity.Y < 0)
					//	npc.velocity.Y = 3;
				}
				else //if (npc.position.Y > target.position.Y + 180)
				{
					//if (Timer % 20 == 0)
						npc.velocity.Y -= 1;

					//if (npc.velocity.Y > 0)
					//	npc.velocity.Y = -3;
				}
			}
			if (moveMode == 0)
			{
				if (!(npc.position.X > target.position.X - 600))
				{
					if (Timer % 20 == 0)
						npc.velocity.X += 1;

					//if (npc.velocity.X > 0)
					//	npc.velocity.X = 3;
				}
				else
					moveMode = 1;
			}
			else if (moveMode == 1)
			{
				if (!(npc.position.X < target.position.X + 600))
				{
					if (Timer % 20 == 0)
						npc.velocity.X -= 1;

					//if (npc.velocity.X > 0)
					//	npc.velocity.X = -3;
				}
				else
					moveMode = 0;
			}
			if (Main.expertMode)
			{
				if (npc.velocity.X > 5)
					npc.velocity.X = 5;
				if (npc.velocity.X < -5)
					npc.velocity.X = -5;
				if (npc.velocity.Y > 5)
					npc.velocity.Y = 5;
				if (npc.velocity.Y < -5)
					npc.velocity.Y = -5;
				if (Timer % 400 == 0)
				{
					attack = Main.rand.Next(1, 3);

					if (attack == 1)
					{
						float numberNPC = Main.rand.Next(1, 5);
						for (int i = 0; i < numberNPC; i++)
						{
							Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("BacteriteEgg"));
						}
					}
					else if (attack == 2)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(target.position) * 4, mod.ProjectileType("CellularResidue"), 13, 10, Main.myPlayer);
						float numberProj = Main.rand.Next(0, 4);
						for (int i = 0; i < numberProj; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 3).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("CellularResidue"), 13, 2, Main.myPlayer);
						}
					}
				}
			}
			else
			{
				if (npc.velocity.X > 4)
					npc.velocity.X = 4;
				if (npc.velocity.X < -4)
					npc.velocity.X = -4;
				if (npc.velocity.Y > 4)
					npc.velocity.Y = 4;
				if (npc.velocity.Y < -4)
					npc.velocity.Y = -4;

				if (Timer % 500 == 0)
				{
					attack = Main.rand.Next(1, 3);

					if (attack == 1)
					{
						float numberNPC = Main.rand.Next(1, 4);
						for (int i = 0; i < numberNPC; i++)
						{
							Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
							NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("BacteriteEgg"));
						}
					}
					else if (attack == 2)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(target.position) * 4, mod.ProjectileType("CellularResidue"), 9, 10, Main.myPlayer);
						float numberProj = Main.rand.Next(0, 3);
						for (int i = 0; i < numberProj; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 3).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("CellularResidue"), 9, 2, Main.myPlayer);
						}
					}
				}
			}
			if (Timer % 4 == 0)
			npc.rotation += 0.04f;
			if (Timer % 1000 == 0)
			{
				moveMode2 = 1;
			}
			if (Timer % 1000 == 150)
			{
				moveMode2 = 0;
			}
			if (Timer % 300 == 0)
			{
				npc.velocity.X -= 2;
			}
			if (Timer % 300 == 150)
			{
				npc.velocity.X += 2;
			}
		}
	}
}