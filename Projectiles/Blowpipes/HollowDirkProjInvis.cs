using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Blowpipes
{
	public class HollowDirkProjInvis : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int Timer;
		bool init;
		int swordsRemaining;
		int swordSpawnSpeed;
        public override void AI() {
			Timer++;
			if (!init) {
				swordsRemaining = (int)Projectile.ai[1];
				swordSpawnSpeed = (int)(30-Projectile.ai[1]);
				if (swordSpawnSpeed < 5) swordSpawnSpeed = 5;
				init = true;
			}

			if ((int)Projectile.ai[0] > -1) Projectile.Center = Main.npc[(int)Projectile.ai[0]].Center;

			if (Timer > swordSpawnSpeed) {
				Timer = 0;
				swordsRemaining--;
				
				Vector2 speed = new Vector2(0, -10).RotatedByRandom(MathHelper.ToRadians(45));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center-speed*45, speed, ModContent.ProjectileType<HollowDirkProj2>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0]);

				speed = new Vector2(0, 10).RotatedByRandom(MathHelper.ToRadians(45));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center-speed*45, speed, ModContent.ProjectileType<HollowDirkProj2>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0]);
			
				Projectile.damage -= 10;
				if (Projectile.damage < 1) Projectile.damage = 1;

				if (swordsRemaining < 1) Projectile.Kill();
			}
        }
	}   
}