using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Wands
{
	public class BigBone : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Big Bone");
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
        public override void AI() {
			if (Projectile.timeLeft > 15) Projectile.alpha -= 17;
			else Projectile.alpha += 17;
            Projectile.velocity *= 0.955f;
			Projectile.rotation += 0.15f;
			if (Main.GameUpdateCount % 8 == 0)
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-7, -3)), ModContent.ProjectileType<Projectiles.BoneFriendlyMagic>(), (int)(Projectile.damage*0.8f), Projectile.knockBack/2, Projectile.owner);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}