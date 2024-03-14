using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class Pukerang : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
		}
		int Timer;
		float speedAcc;
		bool goBack;
		public override void AI() {
			Timer++;
			Projectile.rotation += 0.2f;
			if (Timer >= 40 || goBack) {
				Projectile.ai[0] = 1f; //Allows boomerang to be rethrown while still active
				Projectile.tileCollide = false;
				Vector2 speed = Projectile.Center - Main.player[Projectile.owner].Center;
				if (Math.Abs(speed.X)+Math.Abs(speed.Y) < Projectile.height) {
					Projectile.Kill();
				}
				speed.Normalize();
				speedAcc += 0.05f;
				if (speedAcc > 1f) speedAcc = 1f;
				Projectile.velocity = speed*-15f*speedAcc;
			}
			else if (Timer >= 25) Projectile.velocity *= 0.95f;

			//Projectile shoot code
			float distanceFromTarget = 100f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = false; //between < 100f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			Vector2 projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 10f;
			if (foundTarget) {
				if (Timer % 20 == 0)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir, ModContent.ProjectileType<CursedFlamesMelee>(), Projectile.damage, Projectile.knockBack / 4, Projectile.owner);
			}
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.CursedInferno, 60*Main.rand.Next(6, 11));
            Projectile.damage = (int)(Projectile.damage*0.75f); //multihit penalty
			if (Projectile.damage < 1) Projectile.damage = 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			//goBack = true;
			Projectile.tileCollide = false;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.velocity *= 0.92f;
			return false;
        }
	}   
}