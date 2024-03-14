using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bows
{
	public class CrystalizerProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 30;
			Projectile.ignoreWater = true;
			Projectile.light = 0.3f;
			AIType = ProjectileID.Bullet;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.friendly) { Projectile.Kill(); }
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
		int Timer;
		public override void AI() {
			if (Timer == 0 && Projectile.ai[0] == 3) Projectile.timeLeft = 9999;
			Projectile.rotation += 0.08f;
			Projectile.frame = (int)Projectile.ai[0];
			Timer++;
			if (Timer > 15 || Projectile.ai[0] == 0) Projectile.friendly = true;
			if (Timer % 5 == 0) Projectile.velocity.Y += 1;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Crystal);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
		}
		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter.WithVolumeScale(0.5f).WithPitchOffset(Main.rand.NextFloat(-2f, 2f)), Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.ai[0] < 3 && Main.myPlayer == Projectile.owner) {
				float rand = Main.rand.NextFloat(MathHelper.TwoPi);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(rand), Projectile.type, (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Projectile.owner, Projectile.ai[0]+1f);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(rand+MathHelper.ToRadians(Main.rand.Next(90, 271))), Projectile.type, (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Projectile.owner, Projectile.ai[0]+1f);
            }
		}
	}   
}