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
	public class TargetMegaRandom : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mysterious Target");
		}

        public override void SetDefaults()
		{
			npc.width = 160;
			npc.height = 160;
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
		}
		int flee;
		int Timer;
		int randX;
		int randY;
		bool Laser = true;
		bool setUp = true;
		Vector2 targetPos;
		public override void AI()
		{
			if (Timer < 30)
			npc.color = Color.Green;
			else if (Timer < 60)
			npc.color = Color.Yellow;
			else if (Timer < 90)
			npc.color = Color.Orange;
			else if (Timer < 120)
			npc.color = Color.Red;
			else
			npc.color = Color.DarkRed;

			if (setUp)
			{
				randX = Main.rand.Next(-500, 501);
				randY = Main.rand.Next(-500, 501);
				setUp = false;
			}
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
			targetPos = Main.player[npc.target].Center;
			if (Laser || Main.expertMode)
			{
				if (Main.expertMode)
				{
					npc.position.X = targetPos.X - 80 + (target.velocity.X * 3) + randX;
					npc.position.Y = targetPos.Y - 80 + (target.velocity.Y * 3) + randY;
				}
				else
				{
					npc.position.X = targetPos.X - 80 + randX;
					npc.position.Y = targetPos.Y - 80 + randY;
				}
			}
			npc.rotation += 0.02f;
			if (Timer > 150 && Laser)
			{
				if (Main.expertMode)
				{
					Projectile.NewProjectile(target.position.X + (target.velocity.X * 3) + randX, target.position.Y + 600 + (target.velocity.Y * 3) + randY, 0, -13, mod.ProjectileType("MegaLaser"), 45, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X + (target.velocity.X * 3) + randX, target.position.Y - 600 + (target.velocity.Y * 3) + randY, 0, 13, mod.ProjectileType("MegaLaser"), 45, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X + 600 + (target.velocity.X * 3) + randX, target.position.Y + (target.velocity.Y * 3) + randY, -13, 0, mod.ProjectileType("MegaLaser"), 45, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X - 600 + (target.velocity.X * 3) + randX, target.position.Y + (target.velocity.Y * 3) + randY, 13, 0, mod.ProjectileType("MegaLaser"), 45, 0, Main.myPlayer);
				}
				else
				{
					Projectile.NewProjectile(target.position.X + randX, target.position.Y + 600 + randY, 0, -10, mod.ProjectileType("MegaLaser"), 40, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X + randX, target.position.Y - 600 + randY, 0, 10, mod.ProjectileType("MegaLaser"), 40, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X + 600 + randX, target.position.Y + randY, -10, 0, mod.ProjectileType("MegaLaser"), 40, 0, Main.myPlayer);
					Projectile.NewProjectile(target.position.X - 600 + randX, target.position.Y + randY, 10, 0, mod.ProjectileType("MegaLaser"), 40, 0, Main.myPlayer);
				}
				Laser = false;
				Timer = 0;
			}
			if (Timer > 20 && !Laser)
			{
				if (!Laser)
				npc.life = 0;
			}
		}
	}
}