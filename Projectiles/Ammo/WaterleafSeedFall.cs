using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class WaterleafSeedFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Waterleaf Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = -1;
		}
        public override bool? CanHitNPC(NPC target) {
            return false;
        }
        public override bool CanHitPvp(Player target) {
            return false;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center - new Vector2 (0, 0), new Vector2 (0, 0), ModContent.ProjectileType<WaterleafSprouted>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
		}
	}   
}