using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class IcyInfernus : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Icy Infernus");
        }
		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 3;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
			if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Frostburn, Main.rand.Next(10, 21) * 60, false);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
			if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Frostburn, Main.rand.Next(10, 21) * 60, false);
        }
	}   
}