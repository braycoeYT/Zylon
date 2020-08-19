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

namespace Zylon.NPCs.Minions.Virus
{
	public class MiniPopUp : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mini Popup");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 129;
			npc.height = 88;
			npc.damage = 41;
			npc.defense = 18;
			npc.lifeMax = 220;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = 340;
			npc.damage = 73;
			npc.knockBackResist = 0.74f;
		}
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int flee;
		bool start = true;
		Vector2 landingPos;
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.direction = 1;
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
			}
			if (flee >= 1)
			{
				flee++;
				npc.noTileCollide = true;
				npc.velocity.Y = 7f;
				if (flee >= 450)
					npc.active = false;
			}
			if (start)
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
				start = false;
			}
			if (Timer % 90 == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), ProjectileID.EyeLaser, 24, 2f, Main.myPlayer);
			if (Timer % 200 == 0)
			{
				npc.position = landingPos;
			}
			if ((Timer % 200 == 140 && !Main.expertMode) || (Timer % 200 == 155 && Main.expertMode))
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
				Vector2 visionVelocity;
				visionVelocity.X = 0;
				visionVelocity.Y = 0;
				Projectile.NewProjectile(landingPos, visionVelocity, mod.ProjectileType("MiniPopUpTarget"), 0, 0f, Main.myPlayer);
			}
		}
	}
}