using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class HaxoniteTrail : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flame Orb");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Generic;
			//Projectile.usesLocalNPCImmunity = true;
			//Projectile.localNPCHitCooldown = 10;
			Projectile.scale = 0.75f;
		}
		public override void AI() {
            if (Projectile.timeLeft < 18)
				Projectile.alpha += 15;
			Lighting.AddLight(Projectile.Center, 0.4f, 0f, 0f);
			if (++Projectile.frameCounter >= 3) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
        target.AddBuff(BuffID.OnFire, Main.rand.Next(1, 4)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(1, 4)*60);
        }
        /*public override void PostAI() {
			for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}*/
	}   
}