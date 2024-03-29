using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Blowpipes
{
	public class ShellshockerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Shellshocker");
			Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 1;
			Projectile.frame = Main.rand.Next(3);
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		    target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(2, 5)*60, false);
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(2, 5) * 60, false);
			}
        }

        float totalRot;
        public override void PostAI() {
            totalRot += 0.03f;
			Projectile.rotation = totalRot;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}