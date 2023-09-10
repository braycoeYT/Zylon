using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.Jelly
{
	public class JellyBeamBody : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Jelly Beam");
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
				if (Projectile.ai[1] == 0) {
					Projectile.rotation += MathHelper.ToRadians(90);
					Projectile.position.X += 16;
					Projectile.position.Y -= 16;
				}
				if (Projectile.ai[1] == 1) {
					Projectile.position.X += 48;
					Projectile.position.Y += 16;
				}
				if (Projectile.ai[1] == 2) {
					Projectile.rotation += MathHelper.ToRadians(90);
					Projectile.position.X += 16;
					Projectile.position.Y += 48;
				}
				if (Projectile.ai[1] == 3) {
					Projectile.position.X -= 16;
					Projectile.position.Y += 16;
				}

				Projectile.ai[0] -= 1;
				if (Projectile.ai[0] > 0)
					ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, new Vector2(), ModContent.ProjectileType<JellyBeamBody>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, Projectile.ai[0], Projectile.ai[1], 2);
				else
					ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position, new Vector2(), ModContent.ProjectileType<JellyBeamHead>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, Projectile.ai[0], Projectile.ai[1], 2);
				spawn = true;
			}
		}
	}
}