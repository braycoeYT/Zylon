using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Zylon.Projectiles.Tomes
{
	public class NeedleSpitterProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 2;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.myPlayer == Projectile.owner && !stuck) {
				if (Main.rand.NextBool(4)) { //Sets up "stuck" state.
					stuck = true;
					stuckTarget = target;
					Projectile.usesLocalNPCImmunity = true;
					Projectile.localNPCHitCooldown = 2;
					Projectile.damage = 1;
					Projectile.penetrate = 10;
					Projectile.tileCollide = false;
					safe = target.Center - Projectile.Center;
					Projectile.timeLeft = 180;
					if (Main.rand.NextBool()) target.AddBuff(BuffID.Poisoned, 180);
				}
				else Projectile.Kill(); //Otherwise, don't pierce and DIE
			}
        }
		bool stuck;
		NPC stuckTarget;
		Vector2 safe;
		int Timer;
        public override void AI() {
			if (stuck) {
				Projectile.width = 32;
				Projectile.height = 32;
				Projectile.Center = stuckTarget.Center - safe;
				if (!stuckTarget.active) Projectile.Kill();
				return;
            }
			Timer++;
			if (Timer % 8 == 0) Projectile.velocity.Y += 1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}