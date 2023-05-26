using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class Superstarshot_Y : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Superstarshot");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.scale = 1f;
			Projectile.timeLeft = 400;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            Projectile.damage /= 2;
			if (Projectile.damage < 1 && Projectile.ai[0] == 0f) Projectile.damage = 1;
        }
        int Timer;
        public override void AI() {
			Timer++;
			if (Timer == 2 && (int)Projectile.ai[0] >= 1) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Superstarshot_O>(), 4, Projectile.knockBack/2, Main.myPlayer, Projectile.whoAmI);
			if (Timer == 10 && (int)Projectile.ai[0] >= 2) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Superstarshot_R>(), 3, Projectile.knockBack/3, Main.myPlayer, Projectile.whoAmI);
			if (Timer == 18 && (int)Projectile.ai[0] >= 3) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Superstarshot_F>(), 2, Projectile.knockBack/4, Main.myPlayer, Projectile.whoAmI);
			if (Timer == 26 && (int)Projectile.ai[0] >= 4) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Superstarshot_V>(), 1, Projectile.knockBack/5, Main.myPlayer, Projectile.whoAmI);
        }
		float rot;
        public override void PostAI() {
            rot += 0.2f;
			Projectile.rotation = rot;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}