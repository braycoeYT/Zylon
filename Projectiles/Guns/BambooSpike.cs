using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Guns
{
	public class BambooSpike : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bamboo Spike");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Poisoned, Main.rand.Next(10, 21)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (info.PvP)
            {
				if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Poisoned, Main.rand.Next(10, 21) * 60);
			}
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}