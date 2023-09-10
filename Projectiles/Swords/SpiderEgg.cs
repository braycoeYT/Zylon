using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class SpiderEgg : ModProjectile
	{
        public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Spider Egg");
=======
			// DisplayName.SetDefault("Spider Egg");
>>>>>>> ProjectClash
        }
		public override void SetDefaults() {
			AIType = ProjectileID.WoodenArrowFriendly;
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 3 == 0 && Projectile.aiStyle == 1) Projectile.velocity.Y += 1;
        }
		float newRot;
        public override void PostAI() {
			if (Projectile.aiStyle == 1) newRot += 0.05f;
			Projectile.rotation = newRot;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Web);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.position += Projectile.velocity;
			Projectile.velocity = Vector2.Zero;
			Projectile.aiStyle = -1;
			Projectile.timeLeft = 180;
            return false;
        }
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			float rand = Main.rand.NextFloat(MathHelper.Pi); //maybe base on proj rotation but idk which is better
			for (int i = 0; i < 4; i++) {
				int dustType = DustID.Web;
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;

				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8).RotatedBy(rand+MathHelper.ToRadians(i*90)), ModContent.ProjectileType<VenomFangMelee>(), Projectile.damage/4, Projectile.knockBack/4, Main.myPlayer);
			}
		}
	}   
}