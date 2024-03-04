using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Misc
{
	public class FleshstabJavelin : ModProjectile
	{
		public override void SetDefaults() { //remember AzercadmiumProjectile
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Ichor, 60*Main.rand.Next(5, 11));
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Ichor, 60 * Main.rand.Next(5, 11));
			}
        }

        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < Main.rand.Next(1, 4); i++) {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.position, new Vector2(0, 7).RotatedByRandom(2), ProjectileID.IchorSplash, (int)(Projectile.damage*0.5f), 2.5f, Projectile.owner);
			}
		}
	}   
}