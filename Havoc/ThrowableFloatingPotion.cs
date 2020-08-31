using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Havoc
{
	public class ThrowableFloatingPotion : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Throwable Floating Potion");
        }
		public override void SetDefaults() {
			projectile.width = 23;
			projectile.height = 23;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void AI()
		{
			projectile.rotation += (float)(Math.PI / 180);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center, new Vector2(0, 0), mod.ProjectileType("ThrowableFloatingPotionExp"), projectile.damage, projectile.knockBack, Main.myPlayer);
			Main.PlaySound(SoundID.Shatter);
		}
	}   
}