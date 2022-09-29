using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyBeamCenter : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Beam");
		}
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = false;
		}
		bool spawn;
		public override void AI() {
			if (!spawn) {
				for (int i = 0; i < 4; i++) {
					Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<JellyBeamBody>(), Projectile.damage, 0f, Main.myPlayer, Projectile.ai[0], i);
				}
				spawn = true;
			}
		}
	}
}