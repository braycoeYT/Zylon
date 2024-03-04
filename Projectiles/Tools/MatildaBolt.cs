using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tools
{
	public class MatildaBolt : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 30;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
		}
		int Timer;
        public override void AI() {
            Timer++;
			Projectile.friendly = Timer > Projectile.ai[0];
			Projectile.tileCollide = Timer > Projectile.ai[0];
            if (Timer > Projectile.ai[0]) for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.JungleGrass);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			else Projectile.timeLeft = 30;

			if (Timer == Projectile.ai[0]) Projectile.Center = Main.player[Projectile.owner].Center; //fix offset
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}