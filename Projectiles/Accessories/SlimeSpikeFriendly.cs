using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Accessories
{
	public class SlimeSpikeFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Slime Spike");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Generic;
			AIType = ProjectileID.Seed;
		}
<<<<<<< HEAD
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11)*60);
=======
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11)*60);
>>>>>>> ProjectClash
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11) * 60);
			}
        }

        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}