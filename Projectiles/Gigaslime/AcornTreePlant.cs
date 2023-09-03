using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Gigaslime
{
	public class AcornTreePlant : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Acorn");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.timeLeft = 9999;
			Projectile.friendly = false;
			Projectile.hostile = true;
		}
		float trueRot = Main.rand.NextFloat(0, 2);
        public override void PostAI() {
            trueRot += 0.15f;
			Projectile.rotation = trueRot;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center - new Vector2(0, 65), new Vector2 (0, 0), ModContent.ProjectileType<AcornTreeGrow>(), Projectile.damage, 0f, Main.myPlayer, BasicNetType: 2);
		}
	}   
}