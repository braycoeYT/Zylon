using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles.Swords
{
	public class MarbleGhostSword : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Marble Sword");
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			//AIType = ProjectileID.Bullet;
		}
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.Item15, Projectile.position);
        }
        public override void AI() {
            Projectile.rotation += MathHelper.ToRadians(18);
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 10; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
				dust.scale = 1f;
            }
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}