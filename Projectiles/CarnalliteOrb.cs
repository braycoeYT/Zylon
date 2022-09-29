using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles
{
	public class CarnalliteOrb : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Carnallite Orb");
		}

		public override void SetDefaults() {
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 240;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
		}
		int Timer;
        public override void AI() {
			Timer++;
			if (Timer % 30 == 0)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2(0, -7), ModContent.ProjectileType<Leaf>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 2f);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.CarnalliteDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
    }
}