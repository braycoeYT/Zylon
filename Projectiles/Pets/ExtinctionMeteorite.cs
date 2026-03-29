using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace Zylon.Projectiles.Pets
{
	public class ExtinctionMeteorite : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 140;
            Projectile.height = 140;
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
            return false;
        }
        float newRot;
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            if (!player.dead && player.HasBuff<Buffs.Pets.ExtinctionMeteorite>())
                Projectile.timeLeft = 2;
            return true;
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

			float speed = 12f;
			float inertia = 120f;
			if (distanceToIdlePosition > 400f) {
				speed = 22f;
				inertia = 60f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 12f;
                inertia = 160f;
            }
            if (Main.hardMode && distanceToIdlePosition > 100f) speed *= 2f; //Those darn wings.

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
            if (Projectile.velocity.X < 0) Projectile.spriteDirection = -1;
            else Projectile.spriteDirection = 1;
            newRot += 0.025f*(Math.Abs(Projectile.velocity.X)+Math.Abs(Projectile.velocity.Y))*Projectile.spriteDirection; //Old: 0.04f
            Projectile.rotation = newRot;
            Lighting.AddLight(Projectile.Center, 0.1f, 0f, 0f);
            Projectile.spriteDirection = 0;

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
    }   
}