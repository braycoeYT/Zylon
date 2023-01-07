using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class SparklySlimecasterProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sparkly Slimecaster");
        }
		public override void SetDefaults() {
			Projectile.width = 68;
			Projectile.height = 68;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(320, Main.rand.Next(5, 11)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(320, Main.rand.Next(5, 11)*60);
        }
        public override void AI() {
			Projectile.alpha -= 17;
			Projectile.rotation += 0.15f;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 12; i++)
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -9).RotatedBy(MathHelper.ToRadians(i*30)), ModContent.ProjectileType<SparklyGelFriendly>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/2, Projectile.owner, 2f);
		}
	}   
}