using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Net.NetworkInformation;

namespace Zylon.Projectiles
{
	public class SlimeblastLarge : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Large Slimeblast");
        }
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 30;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 1f;
			aiType = ProjectileID.Bullet;
			projectile.melee = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		int num = Main.rand.Next(5, 9);
		public override void AI()
		{
			projectile.rotation += 0.05f;
		}
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < num; i++)
			{
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 15).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("Slimeblast"), projectile.damage, 6, Main.myPlayer);
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 80);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}