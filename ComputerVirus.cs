using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ComputerVirus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Computer Virus");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 400;
			npc.height = 170;
			npc.damage = 47;
			npc.defense = 11;
			npc.lifeMax = 22500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 120000;
			npc.boss = true;
			npc.lavaImmune = true;
			music = MusicID.Boss4;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.buffImmune[mod.BuffType("Sick")] = false;
			npc.buffImmune[BuffID.Ichor] = false;
			npc.buffImmune[BuffID.CursedInferno] = false;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 35000;
			npc.damage = 79;
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int flee;
		Vector2 landingPos;
		Vector2 targetPos;
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.direction = 1;
			npc.rotation = 0;
			targetPos = Main.player[npc.target].Center;
			Timer++;
			npc.velocity.X = 0;
			npc.velocity.Y = 0;
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
				npc.velocity.Y = 7f;
				if (flee >= 450)
					npc.active = false;
			}
			if (Main.dayTime)
			{
				npc.active = false;
				Color messageColor = Color.DarkSlateGray;
				string chat = "C:Terraria/Zylon/NPCs/Bosses/ComputerVirus failed with 1 error: Overheat Warning (daytime #00=6)";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}

			if (Timer % 90 == 0)
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, ProjectileID.EyeLaser, 24, 2f, Main.myPlayer);
			if (Timer % 200 == 0)
			{
				if ((npc.lifeMax / 2 > npc.life || (Main.expertMode && npc.lifeMax / 1.5f > npc.life)) && Timer % 10 == 0)
				{
					if (Main.rand.NextBool())
					{
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(300, 450);
					}
					else
					{
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(-450, -300);
					}

					if (Main.rand.NextBool())
					{
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(300, 450);
					}
					else
					{
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-450, -300);
					}
				}
				else
				{
					if (Main.rand.NextBool())
					{
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 400);
					}
					else
					{
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(-400, -200);
					}

					if (Main.rand.NextBool())
					{
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 400);
					}
					else
					{
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-400, -200);
					}
				}
				Vector2 visionVelocity;
				visionVelocity.X = 0;
				visionVelocity.Y = 0;
				Projectile.NewProjectile(landingPos, visionVelocity, mod.ProjectileType("ComputerVirusTarget"), 0, 0f, Main.myPlayer);
			}
			if ((Timer % 200 == 60 && !Main.expertMode) || (Timer % 200 == 45 && Main.expertMode))
			{
				npc.Center = landingPos;
				NPC.NewNPC((int)npc.position.X + Main.rand.Next(-400, 401), (int)npc.position.Y + Main.rand.Next(-400, 401), mod.NPCType("MiniPopUp"));
			}
			if ((npc.lifeMax / 2.3f > npc.life || (Main.expertMode)) && Timer % 200 == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("X"));
			}
			if ((npc.lifeMax / 2 > npc.life || (Main.expertMode && npc.lifeMax / 1.5f > npc.life)) && Timer % 10 == 0)
			{
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 6, ProjectileID.EyeFire, 24, 2f, Main.myPlayer);
			}
			if ((npc.lifeMax / 4 > npc.life || (Main.expertMode && npc.lifeMax / 3.2f > npc.life)) && Timer % 135 == 0)
			{
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 5, mod.ProjectileType("SongOfTheVirus"), 24, 2f, Main.myPlayer);
			}
			if ((7500 > npc.life || (Main.expertMode && 10000 > npc.life)) && Timer % 90 == 45)
			{
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, ProjectileID.EyeLaser, 24, 2f, Main.myPlayer);
			}
		}
		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
			if (Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("ComVirusBag"));
			}
			else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("SoulOfByte"), Main.rand.Next(20, 40));
				Item.NewItem(npc.getRect(), ItemID.HallowedBar, Main.rand.Next(15, 31));
			}
			ZylonWorld.downedComVirus = true;
		}
	}
}