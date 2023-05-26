using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Blowpipes
{
	public class TacticalFoamDart : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tactical Foam Dart");
        }
        public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.scale = 0.75f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.FoamDartDebuff>(), 300);
			for (int i = 0; i < 24; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Silver);
				dust.noGravity = true;
				dust.scale = 1.5f;
				dust.velocity = new Vector2(0, 12).RotatedBy(MathHelper.ToRadians(i*15));
			}
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.FoamDartDebuff>(), 300);
			for (int i = 0; i < 24; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.Silver);
				dust.noGravity = true;
				dust.scale = 1.5f;
				dust.velocity = new Vector2(0, 12).RotatedBy(MathHelper.ToRadians(i*15));
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}