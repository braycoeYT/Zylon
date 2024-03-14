using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class IcicleonaRodBreak : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Icicle on a Rod");
        }
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.scale = 1.3f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(2, 4)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(2, 4) * 60);
			}
        }

        int Timer;
        public override void PostAI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
            Timer++;
			if (Timer % 10 == 0) {
				Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.IceGolem, 0, 0, 0, default, 1f);
            }
			if (Timer > 9) Projectile.alpha += 18;
			if (Projectile.alpha > 254) Projectile.Kill();
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IceGolem);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}