using Terraria.ModLoader;
using Terraria;

namespace Zylon.Projectiles.Tools
{
	public class GrammerStagger : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
		int Timer;
		bool init;
        public override void AI() { //ai0 = target, ai1 = crit bool, ai2 = hit direction
			Timer++;
			if (!init) {
				Projectile.timeLeft = 31;
				if (Projectile.ai[1] == 1f) Projectile.timeLeft = 51;
				init = true;
			}

			NPC target = Main.npc[(int)Projectile.ai[0]];
			if (Timer % 10 == 0 && target.life > 1 && target.active && Main.myPlayer == Projectile.owner) {
				NPC.HitInfo a = new();
				a.Crit = (int)Projectile.ai[1] == 1;
				a.Damage = Projectile.damage;
				a.Knockback = Projectile.knockBack;
				a.HitDirection = (int)Projectile.ai[2];
				target.StrikeNPC(a);
			}
        }
	}   
}