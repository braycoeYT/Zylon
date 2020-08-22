using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.OtherBoomerangs
{
	public class Crystalirang : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystalirang");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 630;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(mod.BuffType("XenicAcid"), 240, false);
		}
		int Timer;
		public override void AI() {
			Timer++;
			projectile.timeLeft = 999;
			Vector2 velocity2 = projectile.velocity;
			velocity2 *= 2;
			if (Timer % 60 == 0)
			Projectile.NewProjectile(projectile.Center, velocity2, mod.ProjectileType("GemstoneSpike"), projectile.damage, 2f, Main.myPlayer);
		}
	}   
}