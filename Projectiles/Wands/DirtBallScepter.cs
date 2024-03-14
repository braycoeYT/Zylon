using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Wands
{
	public class DirtBallScepter : ModProjectile
	{
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
		}
        public override void AI() {
            Projectile.alpha -= 15;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.friendly = false;
			Projectile.velocity = new Microsoft.Xna.Framework.Vector2(0, 10);
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.owner == Main.myPlayer) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 3), ModContent.ProjectileType<DirtBallScepter2>(), Projectile.damage, 0f, Projectile.owner);
		}
	}   
}