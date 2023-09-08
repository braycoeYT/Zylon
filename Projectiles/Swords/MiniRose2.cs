using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Zylon.Projectiles.Swords
{
	public class MiniRose2 : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mini Rose");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 150;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 5;
			Projectile.alpha = 255;
		}
		int Timer;
		int dist = 600;
        public override void AI() {
			Projectile.alpha -= 15;
			if (Projectile.alpha < 0) Projectile.alpha = 0;
			Projectile.velocity = Vector2.Zero;
			Timer++;
			dist -= 4;
			Projectile.rotation += 0.04f;
			Projectile.Center = Main.npc[(int)Projectile.ai[1]].Center - new Vector2(0, dist).RotatedBy(MathHelper.ToRadians((Timer*4)+MathHelper.ToRadians(Projectile.ai[0])));
			if (Projectile.timeLeft < 8)
				Projectile.alpha += 60;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}