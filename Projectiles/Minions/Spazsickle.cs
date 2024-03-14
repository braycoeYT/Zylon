using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Minions
{
	public class Spazsickle : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 5;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Summon;
		}
		int Timer;
		Player own;
		public override void AI() {
			Timer++;
			own = Main.player[Projectile.owner];
			Projectile.timeLeft = 2;
			if (own.dead) Projectile.Kill();

			Projectile.Center = own.Center - new Vector2(0, 200).RotatedBy(MathHelper.ToRadians(((float)(Timer*1.25f))+(Projectile.ai[0]*72)));
			Projectile.alpha = 200-(40*Projectile.penetrate); //51

			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			for (int i = Main.rand.Next(0, 3); i < Projectile.penetrate; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
			Projectile.rotation += 0.05f;
		}
        public override void OnKill(int timeLeft) {
            for (int i = 0; i < 15; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
    }   
}