using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Pets
{
	public class DS_91Pet : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 36;
            Projectile.height = 36;
        }
        int Timer;
        public override bool PreAI() {
            Timer++;
            Player player = Main.player[Projectile.owner];

            //Lagging programming
            //Fun fact: The actual pet in-game lags in extremely weird ways sometimes, and I have absolutely no idea why it does that, but it adds so much to the pet that I wanna keep it.
            Projectile.tileCollide = Timer % 600 >= 420;
            if (Timer % 600 >= 420) {
                if (Timer % 5 == 0) Projectile.velocity.Y += 1;
                Projectile.rotation += 0.08f;
            }
            if (!player.dead && player.HasBuff<Buffs.Pets.DS_91Pet>())
                Projectile.timeLeft = 2;
            return Timer % 600 < 420;
        }
        public override void AI() {
            Player player = Main.player[Projectile.owner];

            #region General behavior
			Vector2 idlePosition = player.Center + new Vector2(-60*player.direction, -80);
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			#endregion

            #region Movement

			float speed = 18f;
			float inertia = 70f;
			if (distanceToIdlePosition > 600f) {
				speed = 36f;
				inertia = 50f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 18f;
                inertia = 100f;
            }
            if (Main.hardMode && distanceToIdlePosition > 80f) speed *= 1.5f; //Those darn wings.

			if (distanceToIdlePosition > 20f) {
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else if (Projectile.velocity == Vector2.Zero) {
				Projectile.velocity.X = -0.25f;
			}
            #endregion
        }
        public override void PostAI() {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.spriteDirection = 0;
            if (Timer % 600 >= 420 || (Timer % 2 == 0 && Timer % 600 >= 360)) Projectile.frame = 1;
            else Projectile.frame = 0;

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
            Projectile.velocity *= 0.8f;
			return false;
		}
    }   
}