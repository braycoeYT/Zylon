using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyExpertProj2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mini Jelly");
			Main.projFrames[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		NPC target;
		public override void AI() {
			if (Projectile.alpha > 0 && Projectile.timeLeft > 240)
				Projectile.alpha -= 15;
			if (Projectile.alpha < 255 && Projectile.timeLeft <= 17)
				Projectile.alpha += 15;
			if (++Projectile.frameCounter >= 6) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 2)
					Projectile.frame = 0;
			}
			if (Projectile.timeLeft == 240) {
				Projectile.velocity = 16f * new Vector2((float)Math.Cos(Projectile.rotation), (float)Math.Sin(Projectile.rotation));
			}
			if (Projectile.timeLeft > 240) {
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
						Projectile.rotation = angle;
					}
				}
			}
			Projectile.velocity *= 0.98f;
		}
	}
}