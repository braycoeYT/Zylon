using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Wands
{
	public class TreeTruncheonSapling : ModProjectile
	{
        public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.rotation = 0;
			Projectile.frame = Main.rand.Next(3);
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.damage = (int)(Projectile.damage*0.75f);
			if (Projectile.damage < 1) Projectile.Kill();
        }
		public override void OnKill(int timeLeft) {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_LivingWood);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
    }   
}