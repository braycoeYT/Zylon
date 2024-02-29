using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bows
{
	public class RubyArrow : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
		int Timer;
        public override void AI() {
			Timer++;
            if (Timer % 8 == 0) Projectile.velocity.Y += 1;
			if (Timer == 15 && Projectile.ai[0] == 0f && Main.myPlayer == Projectile.owner) {
				for (int i = 0; i < 2; i++)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(-15f+30f*i)), Projectile.type, (int)(Projectile.damage*0.75f), Projectile.knockBack*0.5f, Projectile.owner, 1f);
				Projectile.Kill();
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}