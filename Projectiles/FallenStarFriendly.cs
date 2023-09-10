using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles
{
	public class FallenStarFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fallen Star");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			AIType = 1;
		}
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
        }
        public override void PostAI() {
            for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = false;
				dust.scale = 1f;
			}
        }
        public override void Kill(int timeLeft) {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust);
				dust.noGravity = false;
				dust.scale = 1f;
			}
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}