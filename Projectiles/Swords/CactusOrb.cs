using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class CactusOrb : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 54;
			Projectile.height = 54;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 150;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.75f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.velocity *= 0.75f;
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			return false;
		}
		Vector2 projDir;
        public override void AI() {
			Projectile.rotation += 0.1f*(Projectile.timeLeft/150f)+0.05f;
            Projectile.velocity *= 0.96f;

			if (Projectile.timeLeft == 60) {
                float distanceFromTarget = 500f;
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
							bool closeThroughWall = between < 150f;

							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
							}
						}
					}
				}
				if (foundTarget) projDir = Vector2.Normalize(targetCenter - Projectile.Center) * 0.25f;
				if (projDir == Vector2.Zero) projDir = Vector2.Normalize(targetCenter - Main.MouseWorld) * -0.25f;

				Projectile.tileCollide = !foundTarget;
            }
			if (Projectile.timeLeft > 20 && Projectile.timeLeft < 60 && Projectile.timeLeft % 8 == 0 && Main.myPlayer == Projectile.owner)
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, projDir*40f, ModContent.ProjectileType<CactusOrb_Proj>(), Projectile.damage/2, Projectile.knockBack/2f, Projectile.owner);

			if (Projectile.timeLeft <= 10) Projectile.alpha += 36;
		}
        public override void PostAI() {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Cactus);
			dust.noGravity = true;
			dust.scale = 1f;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}