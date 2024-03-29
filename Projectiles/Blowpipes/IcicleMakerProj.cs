using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Blowpipes
{
	public class IcicleMakerProj : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Mini Icicle");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.scale = 0.75f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 4)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 4) * 60);
			}
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}