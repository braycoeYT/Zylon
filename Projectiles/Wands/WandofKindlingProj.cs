using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class WandofKindlingProj : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 45;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            int f = BuffID.OnFire;
            if (Projectile.ai[0] == 1f) f = BuffID.ShadowFlame;
            target.AddBuff(f, Main.rand.Next(2, 5)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
                int f = BuffID.OnFire;
                if (Projectile.ai[0] == 1f) f = BuffID.ShadowFlame;
                target.AddBuff(f, Main.rand.Next(2, 5)*60);
            }
        }
        int Timer;
        public override void AI() {
            Timer++;
            if (Timer % 10 == 0) Projectile.velocity.Y++;
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
        public override void OnKill(int timeLeft) {
            if (Main.myPlayer == Projectile.owner) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-30, -19))), ModContent.ProjectileType<WandofKindlingProj_2>(), (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Main.myPlayer, Projectile.ai[0]);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.Next(20, 31))), ModContent.ProjectileType<WandofKindlingProj_2>(), (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Main.myPlayer, Projectile.ai[0]);
            }
        }

    }   
}