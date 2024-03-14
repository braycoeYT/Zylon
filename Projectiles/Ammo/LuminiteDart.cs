using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class LuminiteDart : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            for (int i = 0; i < 3; i++)
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<LuminiteDartReplica>(), Projectile.damage/2, 0f, Projectile.owner, target.whoAmI, i);
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}