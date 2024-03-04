using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class OozeCloud : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ooze Cloud");
			Main.projFrames[Projectile.type] = 5;
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 240;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 15;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		    target.AddBuff(BuffID.Poisoned, Main.rand.Next(3, 8)*60);
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Poisoned, Main.rand.Next(3, 8) * 60);
			}
        }
        public override void AI() {
			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 5)
					Projectile.frame = 0;
			}
			if (Projectile.timeLeft < 18) Projectile.alpha += 15;
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}