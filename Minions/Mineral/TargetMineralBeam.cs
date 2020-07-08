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

namespace Zylon.NPCs.Minions.Mineral
{
	public class TargetMineralBeam : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("test");
		}

        public override void SetDefaults() {
			npc.width = 4;
			npc.height = 1560;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 0;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
			npc.alpha = 127;
		}
		int flee;
		int Timer;
		bool Laser = true;
		Vector2 targetPos;
		public override void AI() {
			Player target = Main.player[npc.target];
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
				if (flee >= 450)
					npc.active = false;
			}
			npc.position.X = target.position.X + (target.velocity.X * 45) + 10;
			npc.position.Y = target.position.Y - 780;
			if (Timer > 150 && Laser)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("MineralLaserBeam"), 45, 0, Main.myPlayer);
				Laser = false;
				npc.life = 0;
			}
		}
	}
}