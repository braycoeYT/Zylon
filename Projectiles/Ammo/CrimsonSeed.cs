using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class CrimsonSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Crimson Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = 4;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.CritChance += 10;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                Projectile.CritChance += 10;
            }
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}