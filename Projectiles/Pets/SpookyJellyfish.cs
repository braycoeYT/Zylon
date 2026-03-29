using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Pets
{
	public class SpookyJellyfish : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 28;
            Projectile.height = 28;
        }
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.Pets.SpookyJellyfish>())
                Projectile.timeLeft = 2;
            return true;
        }
        int Timer;
        int alph;
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

			float speed = 10f;
			float inertia = 30f;
			if (distanceToIdlePosition > 300f) {
				speed = 30f;
				inertia = 3f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 10f;
                inertia = 50f;
            }
            if (Main.hardMode && distanceToIdlePosition > 100f) speed *= 1.5f; //Those darn wings.

			if (distanceToIdlePosition > 20f) {
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else if (Projectile.velocity == Vector2.Zero) {
				Projectile.velocity.X = -0.15f;
                Projectile.velocity.Y = -0.05f;
			}
            #endregion
        }
        public override void PostAI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = 0;
            Timer++;
            if (Projectile.frame > 1) Projectile.frame = 0;
            if (Timer % 360 >= 270)
                alph += 15;
            else alph -= 15;
            if (alph > 255) alph = 255;
            if (alph < 0) alph = 0;
            Projectile.alpha = alph;

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
    }   
}