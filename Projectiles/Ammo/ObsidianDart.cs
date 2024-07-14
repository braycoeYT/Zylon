using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class ObsidianDart : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Obsidian Dart");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		float power;
		bool init;
        public override void AI() {
            if (!init) {
				power = Projectile.velocity.Length();
				init = true;
				if (power > 30f) power = 30f;
				power *= 0.025f;
			}
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Obsidian);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < power) for (int i = 0; i < Main.rand.Next(3, 5); i++) {
				if (Projectile.owner == Main.myPlayer) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<ObsidianDartShard>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/2f, Projectile.owner);
			}
		}
	}   
}