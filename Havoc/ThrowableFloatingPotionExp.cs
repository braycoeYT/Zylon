using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Havoc
{
	public class ThrowableFloatingPotionExp : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwable Floating Potion");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.boss == false && target.type != NPCID.TargetDummy && target.type != mod.NPCType("XenicAcidpumperGood"))
			target.velocity.Y -= 10;
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.velocity.Y -= 10;
		}
		public override void AI()
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 56;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}