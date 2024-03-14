using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class TreeTruncheonAcorn : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.damage = (int)(Projectile.damage*0.85f);
        }
        public override void AI() {
			Projectile.alpha -= 27;
			Projectile.velocity.Y += 0.5f;
			Projectile.velocity.X *= 0.97f;
			if (Projectile.velocity.Y > 12) Projectile.velocity.Y = 12;

			Projectile.rotation += 0.05f*Projectile.velocity.X+0.08f;

			//Passive dust spawn
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 4), Vector2.Zero, ModContent.ProjectileType<TreeTruncheonSapling>(), Projectile.originalDamage, 1f, Projectile.owner);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}