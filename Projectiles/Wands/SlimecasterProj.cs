using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class SlimecasterProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Slimecaster");
        }
		public override void SetDefaults() {
			Projectile.width = 44;
			Projectile.height = 44;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Slimed, Main.rand.Next(5, 11) * 60);
			}
        }
		int Timer;
        public override void AI() {
			Projectile.alpha -= 17;
			Projectile.rotation += 0.25f;
			Timer++;
			if (Timer % 3 == 0) Projectile.velocity.Y += 1;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 12; i++)
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*30)), ModContent.ProjectileType<SlimecasterSlimeSpike>(), (int)(Projectile.damage*0.8f), Projectile.knockBack/2, Projectile.owner);
		}
	}   
}