using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Wands
{
	public class VaporsEonShower : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.WaterStream);
			AIType = ProjectileID.WaterStream;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Wet, 420, false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Wet, 420, false);
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}