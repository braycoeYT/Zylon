using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Blowpipes
{
	public class UnholyEnergy : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Unholy Energy");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.scale = 0.33f;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
		}
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Corruption);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
		}
		bool init;
		int Timer;
		int wait = Main.rand.Next(46);
		public override void AI() {
			Lighting.AddLight(Projectile.Center, 0.5f*Projectile.alpha/255, 0f, 0.5f*Projectile.alpha/255);
			Timer++;
			if (wait <= Timer) Projectile.alpha -= 15;
			if (!init) {
				Vector2 temp = Projectile.Center - Main.MouseWorld;
				temp.Normalize();
				Projectile.velocity = temp*-8f;
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				if (Projectile.alpha > 0) Projectile.velocity = Vector2.Zero;
				else init = true;
			}
			else {
				Projectile.velocity *= 1.01f;
				Projectile.tileCollide = Timer > 60;
            }
		}
	}   
}