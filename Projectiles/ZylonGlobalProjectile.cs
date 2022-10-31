using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class ZylonGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true;
		public override void SetDefaults(Projectile projectile) {
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (projectile.type == ProjectileID.Flare || projectile.type == ProjectileID.BlueFlare)
					projectile.timeLeft = 3600;
			}
		}
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) {
            if (target.type == NPCType<NPCs.Bosses.Dirtball.DirtBlock>() && (projectile.penetrate < 0 || projectile.penetrate > 3) && projectile.minion == false && Main.expertMode)
				projectile.penetrate = 3;
        }
    }
}