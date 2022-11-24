using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Misc
{
	public class SturgeonsKnife : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sturgeon's Knife");
        }
		public override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 6;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			Projectile.Kill();
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			Projectile.Kill();
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
        public override void AI() {
            if (Main.GameUpdateCount % 3 == 0) Projectile.velocity.Y += 1;
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 4);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(6, 0), ModContent.ProjectileType<AquaBubble>(), 1, 0.1f, Main.myPlayer);
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-6, 0), ModContent.ProjectileType<AquaBubble>(), 1, 0.1f, Main.myPlayer);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}