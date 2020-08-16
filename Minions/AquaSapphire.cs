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
	public class AquaSapphire : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aquatic Sapphire");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 59;
			npc.height = 59;
			npc.damage = 88;
			npc.defense = 77;
			npc.lifeMax = 987;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
			npc.buffImmune[mod.BuffType("XenicAcid")] = true;
        }
		public float Timer
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		int flee;
		public override void AI()
		{
			npc.AddBuff(BuffID.Wet, 9, false);
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

			if (Timer % 480 == 0)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("BlueGemblast"), 10, 2, Main.myPlayer);
			if (Timer % 100 == 0)
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
            npc.lifeMax = 1876;
            npc.damage = 93;
			npc.defense = 98;
        }
	}
}