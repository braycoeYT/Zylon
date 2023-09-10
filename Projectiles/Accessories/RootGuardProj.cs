using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Accessories
{
	public class RootGuardProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Root Guard");
			Main.projFrames[Projectile.type] = 9;
        }
        public override void SetDefaults() {
            Projectile.width = 24;
			Projectile.height = 56;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.rotation = MathHelper.ToRadians(Main.rand.Next(-20, 21));
			Projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (Timer < 145) Timer = 152;
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (info.PvP)
            {
				if (Timer < 145) Timer = 152;
			}
        }
        int Timer;
        public override void AI() {
			Timer++;
			Projectile.friendly = Timer > 12 && Timer < 156;
			if (Timer > 145) {
				Projectile.frame = 60 - Timer/3;
				if (Projectile.frame > 8) Projectile.frame = 8;
			}
			else {
				Projectile.frame = Timer/3;
				if (Projectile.frame > 8) Projectile.frame = 8;
			}
			if (Timer == 25) {
				for (int i = 0; i < 4; i++) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
					dust.velocity = new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-6, -4));
					dust.noGravity = false;
					dust.scale = Main.rand.NextFloat(0.7f, 1.2f);
				}
            }
			if (Timer > 180) Projectile.active = false;
        }
    }
}