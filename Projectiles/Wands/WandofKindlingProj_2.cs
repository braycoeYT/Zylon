using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class WandofKindlingProj_2 : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 45;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            int f = BuffID.OnFire;
            if (Projectile.ai[0] == 1f) f = BuffID.ShadowFlame;
            target.AddBuff(f, Main.rand.Next(2, 5)*30);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
                int f = BuffID.OnFire;
                if (Projectile.ai[0] == 1f) f = BuffID.ShadowFlame;
                target.AddBuff(f, Main.rand.Next(2, 5)*30);
            }
        }
        int Timer;
        public override void AI() {
            Timer++;
            if (Timer % 5 == 0) Projectile.velocity.Y++;
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
                int f = DustID.Torch;
                if (Projectile.ai[0] == 1f) f = DustID.Shadowflame;
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, f);
				dust.noGravity = true;
				dust.scale = 1.75f;
			}
        }
        public override void Kill(int timeLeft) {
            base.Kill(timeLeft);
        }
    }   
}