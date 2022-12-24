using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class MeteoragaBlast : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
		}
        public override void AI() {
            Projectile.velocity *= 1.008f;
			Projectile.rotation += 0.1f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
        public override void Kill(int timeLeft) {
			for (int i = 0; i < 8; i++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<Projectiles.Blowpipes.MeteoragaBlastFireball>(), (int)(Projectile.damage*0.75f), Projectile.knockBack*0.5f, Main.myPlayer);
            }
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}