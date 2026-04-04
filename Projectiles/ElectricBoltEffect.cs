using Terraria.ModLoader;
using Terraria;

namespace Zylon.Projectiles
{
	public class ElectricBoltEffect : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int Timer;
		bool init;
        public override void AI() { //ai0 = target, ai1 = damage type, ai2 = hit direction
			Timer++;
			if (!init) {
				Projectile.timeLeft = 31;
				init = true;

				switch (Projectile.ai[1]) {
					case 0f: Projectile.DamageType = DamageClass.Melee;
						return;
					case 1f: Projectile.DamageType = DamageClass.Ranged;
						return;
					case 2f: Projectile.DamageType = DamageClass.Magic;
						return;
					case 3f: Projectile.DamageType = DamageClass.Summon;
						return;
				}
			}

			NPC target = Main.npc[(int)Projectile.ai[0]];
			if (Timer % 5 == 0 && target.life > 1 && target.active && Main.myPlayer == Projectile.owner) {
				NPC.HitInfo a = new();
				a.Crit = Main.rand.NextFloat() < 0.04f;
				a.Damage = Projectile.damage;
				a.Knockback = Projectile.knockBack;
				a.HitDirection = (int)Projectile.ai[2];
				target.StrikeNPC(a);
			}
        }
	}   
}