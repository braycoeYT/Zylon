using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Accessories
{
	public class BloodContractProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blood Contract");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 210;
			Projectile.tileCollide = false;
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer % 45 == 0)
				if (Main.player[Projectile.owner].Center.X < Projectile.Center.X) Projectile.velocity.X -= 1;
				else Projectile.velocity.X += 1;
            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) < 30) {
				Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
				Projectile.Kill();
            }
        }
        public override void PostAI() {
			for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
            if (timeLeft > 0) SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.position);
			for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
    }   
}