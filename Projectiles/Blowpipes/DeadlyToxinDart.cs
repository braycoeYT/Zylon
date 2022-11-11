using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Blowpipes
{
	public class DeadlyToxinDart : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.DeadlyToxins>(), Main.rand.Next(8, 16)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.DeadlyToxins>(), Main.rand.Next(8, 16)*60);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}