using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class Leaf : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Leaf");
			Main.projFrames[Projectile.type] = 5;
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			AIType = ProjectileID.WoodenArrowFriendly;
			switch (Projectile.ai[0]) {
				case 0f: Projectile.DamageType = DamageClass.Melee;
					return;
				case 1f: Projectile.DamageType = DamageClass.Ranged;
					return;
				case 2f: Projectile.DamageType = DamageClass.Magic;
					return;
				case 3f: Projectile.DamageType = DamageClass.Summon;
					return;
            }
			
		}
        public override void AI() {
            int frameSpeed = 3;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed) {
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}