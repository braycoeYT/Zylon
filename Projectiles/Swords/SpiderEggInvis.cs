using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class SpiderEggInvis : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spider Egg");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.timeLeft = 240;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
        public override void AI() {
			Projectile.Center = Main.npc[(int)Projectile.ai[0]].Center;
        }
		float newRot;
        public override void PostAI() {
			//if (Projectile.aiStyle == 1) newRot += 0.05f;
			Projectile.rotation = newRot;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Web);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);
			Projectile.rotation = Main.rand.NextFloat(MathHelper.Pi);
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