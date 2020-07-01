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

namespace Zylon.NPCs.Minions
{
	public class SproutingEmerald : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sprouted Emerald");
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 69;
			npc.height = 69;
			npc.damage = 97;
			npc.defense = 58;
			npc.lifeMax = 867;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int flee;
		public override void AI()
		{
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

			if (Timer % 320 == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("GreenGemblast"), 10, 2, Main.myPlayer);
			if (Timer % 150 == 0)
			{
				if (Main.rand.NextBool())
				{
					npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(120, 500);
				}
				else
				{
					npc.position.X = Main.player[npc.target].Center.X + Main.rand.Next(-500, -120);
				}

				if (Main.rand.NextBool())
				{
					npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(120, 500);
				}
				else
				{
					npc.position.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-500, -120);
				}
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1576;
            npc.damage = 119;
			npc.defense = 89;
        }
	}
}