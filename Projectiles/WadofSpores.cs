using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles
{
	public class WadofSpores : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Wad of Spores");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 6; i++)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Microsoft.Xna.Framework.Vector2(0, 8).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<JungleSporeRanged2>(), Projectile.damage, Projectile.knockBack/2, Projectile.owner);
		}
	}   
}