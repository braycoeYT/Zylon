using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class BlinkrootSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blinkroot");
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 5;
			Projectile.rotation = 0;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (target.boss == false)
				target.velocity *= 0.25f;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.velocity *= 0.25f;
        }
	}   
}