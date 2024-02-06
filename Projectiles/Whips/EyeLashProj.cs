using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Whips
{
	public class EyeLashProj : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 25;
			Projectile.height = 25;
			Projectile.aiStyle = -1;
			//Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
			//Projectile.extraUpdates = 1;
			Projectile.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		int Timer;
		float distanceFromTarget = 99999f;
        public override void AI() {
			//if (Timer == 0) targetCenter = Projectile.position + new Vector2(Main.rand.Next(-300, 301), Main.rand.Next(-300, 301));
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;
			Timer++;
			if (Timer < 60) {
				Projectile.alpha -= 5;
				if (!foundTarget) {
					for (int i = 0; i < Main.maxNPCs; i++) {
						NPC npc = Main.npc[i];
						if (npc.CanBeChasedBy() && npc.life > 0) {
							float between = Vector2.Distance(npc.Center, Projectile.Center);
							bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
							bool closeThroughWall = true; //between < 100f;

							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
								Vector2 direction = targetCenter - Projectile.Center;
								Projectile.rotation = direction.ToRotation() + MathHelper.PiOver2;
							}
						}
					}
				}
            }
			else if (Timer < 80) {
				Projectile.friendly = true;
				Projectile.velocity = new Vector2(0, -12).RotatedBy(Projectile.rotation);
            }
			else if (Timer < 110) {
				Projectile.alpha += 10;
				Projectile.velocity *= 0.95f;
            }
			else Projectile.Kill();
        }
	}   
}