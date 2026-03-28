using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Ammo
{
	public class BouncyPocketGrenade : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BouncyGrenade);
			AIType = ProjectileID.BouncyGrenade;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;

			ZylonGlobalProjectile p = Projectile.GetGlobalProjectile<ZylonGlobalProjectile>();
			p.zDart = true;
		}
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.velocity.Y = oldVelocity.Y * -0.85f;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (Projectile.timeLeft > 2) Projectile.timeLeft = 2;
			if (Projectile.width == 10) {
				Projectile.width = 64;
				Projectile.height = 64;
				Projectile.position -= new Vector2(27, 27);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				if (Projectile.width == 10) {
					Projectile.width = 64;
					Projectile.height = 64;
					Projectile.position -= new Vector2(27, 27);
				}
				if (Projectile.timeLeft > 2) Projectile.timeLeft = 2;
			}
        }
		public override bool PreAI() {
            if (Projectile.timeLeft == 2 && Projectile.width == 10) {
				Projectile.width = 64;
				Projectile.height = 64;
				Projectile.position -= new Vector2(27, 27);
			}
			return true;
        }
        public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 20; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
		}
    }   
}