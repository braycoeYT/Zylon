using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Guns
{
	public class ClockworkBit : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (!target.boss && target.type != NPCID.GolemHead && target.type != NPCID.SkeletronHand && Main.rand.NextFloat() < .2f) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(1, 4)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .1f) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(1, 3)*60);
        }
        public override void AI() {
            Projectile.rotation += 0.1f;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}