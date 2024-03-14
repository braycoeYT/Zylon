using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace Zylon.Projectiles.Enemies
{
	public class CerussiteBatProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Elemental Slime Spike");
			Main.projFrames[Projectile.type] = 8;
        }
		public override void SetDefaults() {
			//Projectile.CloneDefaults(ProjectileID.Seed);
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.frame = Main.rand.Next(8);
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = -1;
		}
		int Timer;
		float rand = Main.rand.NextFloat(0.05f, 0.15f);
        public override void AI() {
			Projectile.rotation += rand;
            Timer++;
			if (Timer % 3 == 0 && Projectile.velocity.Y < 16) Projectile.velocity.Y += 1;
        }
        public override void PostAI() {
			int dustType = 0;
			switch (Projectile.frame) {
				case 0:
					dustType = DustID.GemAmethyst;
					return;
				case 1:
					dustType = DustID.GemTopaz;
					return;
				case 2:
					dustType = DustID.GemSapphire;
					return;
				case 3:
					dustType = DustID.GemEmerald;
					return;
				case 4:
					dustType = DustID.GemRuby;
					return;
				case 5:
					dustType = DustID.GemDiamond;
					return;
				case 6:
					dustType = DustID.GemAmber;
					return;
				case 7:
					dustType = ModContent.DustType<Dusts.JadeDust2>();
					return;
            }
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter.WithPitchOffset(1f), Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}