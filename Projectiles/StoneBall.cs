using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class StoneBall : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Ball");
		}

		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			AIType = ProjectileID.WoodenArrowFriendly;
		}

        public override void AI()
        {
			Projectile.ai[0]++;
			Projectile.rotation += 0.1f;
			if (Projectile.ai[0] >= 12f)
				Projectile.velocity.Y += 0.35f;
			if (Projectile.velocity.Y >= 16f)
				Projectile.velocity.Y = 16f;
        }


        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}