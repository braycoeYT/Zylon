using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class CryoWandProjShard : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Cryo Wand");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			AIType = ProjectileID.Seed;
		}
		int Timer;
		float newRot;
        public override void AI() {
            Timer++;
			if (Timer % 8 == 0) Projectile.velocity.Y += 1;
        }
        public override void PostAI() {
            newRot += 0.08f;
			Projectile.rotation = newRot;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(2, 5)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
                target.AddBuff(BuffID.Frostburn, Main.rand.Next(2, 5) * 60);
            }
        }

    }   
}