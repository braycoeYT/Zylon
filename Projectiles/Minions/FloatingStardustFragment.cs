using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Minions
{
	public class FloatingStardustFragment : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Floating Stardust Fragment");
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			//ProjectileID.Sets.Homing[Projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 5;
			Projectile.DamageType = DamageClass.Summon;
		}
		public override bool? CanCutTiles() {
			return true;
		}
		public override bool MinionContactDamage() {
			return attackMode == 2;
		}
		int Timer;
		int rand = Main.rand.Next(0, 40);
		int attackMode;
		Vector2 tempVect;
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            modifiers.ScalingBonusDamage += Projectile.scale - 1f;
        }
        public override void AI() {
			Player player = Main.player[Projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.FloatingStardustFragment>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.FloatingStardustFragment>()))
			{
				Projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center;

			float minionPositionOffsetX = (32 + Projectile.minionPos * 20) * -player.direction; //40
			idlePosition.X += minionPositionOffsetX;
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) Projectile.velocity.X -= overlapVelocity;
					else Projectile.velocity.X += overlapVelocity;

					if (Projectile.position.Y < other.position.Y) Projectile.velocity.Y -= overlapVelocity;
					else Projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 1000f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = true; //Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			if (foundTarget && (distanceFromTarget > 2000f || (distanceFromTarget > 1000f && !player.HasMinionAttackTargetNPC))) foundTarget = false; //WHY DOES THIS HAVE TO BE HERE
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 28f;
			float inertia = 60f;

			if (foundTarget)
			{
				if (distanceFromTarget > 40f && distanceFromTarget < 2000f) {
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 34f;
					inertia = 80f;
				}
				else {
					speed = 26f;
					inertia = 100f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
			#endregion

			#region Animation and visuals
			if (attackMode == 0) Projectile.rotation += 0.03f*Projectile.scale;

			Lighting.AddLight(Projectile.Center, Color.DeepSkyBlue.ToVector3() * 0.64f);
			#endregion

			if (foundTarget) {
				Timer++;
            }
			else {
				Timer = 0;
				attackMode = 0;
				if (Projectile.scale > 1f) {
					Projectile.scale -= 0.1f;
					if (Projectile.scale < 1f) Projectile.scale = 1f;
                }
            }
			if (attackMode == 0 && foundTarget) {
				float quickInt = 15 - Timer;
				if (quickInt < 0) quickInt = 0;
				Projectile.velocity *= quickInt/15;
				if (Timer > 14) attackMode = 1;
            }
			if (attackMode == 1 && foundTarget) {
				Projectile.velocity = Vector2.Zero;
				Projectile.scale += 0.05f;
				Projectile.rotation += 0.03f*Projectile.scale;
				if (Projectile.scale > 2.5f) {
					Projectile.scale = 2.5f;
					attackMode = 2;
					Timer = 0;
                }
            }
			if (attackMode == 2 && foundTarget) {
				Projectile.rotation += 0.03f*Projectile.scale;
				if (Timer % 12 == 0) {
					tempVect = Vector2.Normalize(Projectile.Center - targetCenter) * (float)(-17.5f);
					Projectile.scale -= 0.1f;
                }
				Projectile.velocity = tempVect;
				if (Projectile.scale <= 1f) {
					Projectile.scale = 1f;
					Timer = 0;
					attackMode = 3;
                }
            }
			if (attackMode == 3 && foundTarget) {
				Projectile.rotation += 0.03f;
				/*if (Timer % 6 == 0) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -5).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<StardustBeam>(), Projectile.damage/2, Projectile.knockBack/2, Main.myPlayer);
                }*/
				if (Timer >= 30) {
					Timer = 0;
					Projectile.scale = 1f;
					attackMode = 0;
                }
				Timer++;
            }
		}
	}
}