using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Zylon.Projectiles.Swords
{
	public class MiniRose : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 360;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 5;
		}
		Vector2 spawn;
		int Timer;
		int dist;
        public override void AI() {
			Projectile.velocity = Vector2.Zero;
			if (Timer == 0) spawn = Projectile.Center;
			Timer++;
			dist += 1;
			Projectile.rotation += 0.04f;
			Projectile.Center = spawn - new Vector2(0, dist).RotatedBy(MathHelper.ToRadians((Timer*4)+Projectile.ai[0]*45));//((float)Math.Pow(Timer*2, 1.1f))+Projectile.ai[0]*45));
			if (Projectile.timeLeft < 28)
				Projectile.alpha += 10;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}