using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class BloodBall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blood Ball");
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 480;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			//Projectile.scale = 0.02f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.Center);
			end = true;
			Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
		}
		bool init;
		bool end;
		float rot;
        public override void AI() {
			Player main = Main.player[Projectile.owner];
			if (!init) {
				Projectile.alpha -= 5;
				if (Projectile.alpha <= 0) {
					init = false;
					Projectile.friendly = true;
					Projectile.alpha = 0;
                }
            }
			if (end || Projectile.timeLeft < 60) {
				Projectile.friendly = false;
				Projectile.alpha += 17;
				if (Projectile.alpha >= 255) Projectile.active = false;
				return;
            }
			rot += 2;
			Projectile.rotation += 0.02f;
			Projectile.Center = main.Center - new Vector2(0, 40+(int)(rot/10)).RotatedBy(MathHelper.ToRadians((360/Projectile.ai[1]*Projectile.ai[0])+rot));
			if (main.active == false) Projectile.active = false;
        }
        public override void PostAI() {
			for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Blood);
				dust.noGravity = true;
				dust.scale = 0.5f + Projectile.scale/2;
			}
		}
	}   
}