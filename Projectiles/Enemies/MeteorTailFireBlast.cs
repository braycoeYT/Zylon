using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Enemies
{
	public class MeteorTailFireBlast : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fire Blast");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 45;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(3, 7));
        }
		public override void PostAI() {
			for (int i = 0; i < 3; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}