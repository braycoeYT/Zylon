using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Swords
{
	public class JourneyStarterBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Journey Starter");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.light = 0.25f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Projectile.ai[0] % 3 == 0) target.AddBuff(BuffID.OnFire, Main.rand.Next(8, 16)*60);
			Projectile.damage = (int)(Projectile.damage*0.5f);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				if (Projectile.ai[0] % 3 == 0) target.AddBuff(BuffID.OnFire, Main.rand.Next(8, 16) * 60);
			}
        }
        public override void AI() {
			if (Projectile.ai[0] % 3 == 1) Projectile.velocity *= 1.025f;
			if (Projectile.ai[0] % 3 == 2 && Projectile.timeLeft == 9998) Projectile.penetrate = -1;
			int whatDust = 6; //orange
			if (Projectile.ai[0] % 3 == 1) whatDust = 75; //green
			if (Projectile.ai[0] % 3 == 2) whatDust = 135; //cyan
            for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, whatDust);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}