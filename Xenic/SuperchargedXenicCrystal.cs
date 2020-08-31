using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Xenic
{
	public class SuperchargedXenicCrystal : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supercharged Xenic Crystal");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("XenicAcid"), 90, false);
		}
		int xenicRan = Main.rand.Next(2, 5);
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center, new Vector2(0, 6), mod.ProjectileType("ChargedXenicCrystal"), projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, new Vector2(0, -6), mod.ProjectileType("ChargedXenicCrystal"), projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, new Vector2(6, 0), mod.ProjectileType("ChargedXenicCrystal"), projectile.damage, 6, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center, new Vector2(-6, 0), mod.ProjectileType("ChargedXenicCrystal"), projectile.damage, 6, Main.myPlayer);
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 193);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}