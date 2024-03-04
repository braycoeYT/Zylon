using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.ID;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyExpertProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Big Eerie Jellyfish");
			Main.projFrames[Projectile.type] = 3;
		}
		public override void SetDefaults() {
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 210;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		NPC target;
		int Timer;
		public override void AI() {
			Timer++;
			if (Projectile.alpha > 0 && Projectile.timeLeft > 193)
				Projectile.alpha -= 15;
			if (Projectile.alpha < 255 && Projectile.timeLeft <= 17)
				Projectile.alpha += 15;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
			if (Main.maxNPCs > 0 && Main.maxNPCUpdates > 0) {
				lowestDistance = 999999;
				int npcCount;
				target = Main.npc[0];
				for (npcCount = 0; npcCount < Main.maxNPCs; npcCount++) {
					if (Main.npc[npcCount].active && !Main.npc[npcCount].townNPC && !Main.npc[npcCount].friendly) {
						if (Vector2.Distance(Projectile.Center, Main.npc[npcCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(Projectile.Center, Main.npc[npcCount].Center);
							target = Main.npc[npcCount];
						}
					}
				}
				if (target.active && target != null && Main.maxNPCs > 0 && Main.maxNPCUpdates > 0)
				{
					Vector2 look = target.Center - Projectile.Center;
					if (look.X != 0f) {
					angle = (float)Math.Atan(look.Y / look.X);
					}
					else if (look.Y < 0f) {
						angle += (float)Math.PI;
					}
					if (look.X < 0f) {
						angle += (float)Math.PI;
					}
					if (Timer == 18)
					Projectile.rotation = angle;
				}
				if (Timer == 17)
					Projectile.velocity = (Projectile.Center - target.Center) * (-0.022f);
			}
			Projectile.velocity *= 0.98f;
			if (Projectile.timeLeft == 1) {
				for (int i = 0; i < 4; i++)
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 10).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<JellyExpertProj2>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, BasicNetType: 2);
			}
		}
	}
}