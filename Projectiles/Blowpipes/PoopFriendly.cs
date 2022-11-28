using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Blowpipes
{
	public class PoopFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Poop");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Poisoned, 69);
			target.AddBuff(BuffID.OnFire, 69);
			target.AddBuff(BuffID.Frostburn, 69);
			target.AddBuff(BuffID.Venom, 69);
			target.AddBuff(BuffID.Daybreak, 69);
			target.AddBuff(BuffID.CursedInferno, 69);
			target.AddBuff(BuffID.Ichor, 69);
			target.AddBuff(BuffID.ShadowFlame, 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 69);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Poisoned, 69);
			target.AddBuff(BuffID.OnFire, 69);
			target.AddBuff(BuffID.Frostburn, 69);
			target.AddBuff(BuffID.Venom, 69);
			target.AddBuff(BuffID.Daybreak, 69);
			target.AddBuff(BuffID.CursedInferno, 69);
			target.AddBuff(BuffID.Ichor, 69);
			target.AddBuff(BuffID.ShadowFlame, 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 69);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}