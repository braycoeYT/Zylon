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
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bouncy Pocket Grenade");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.BouncyGrenade);
			AIType = ProjectileID.BouncyGrenade;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
		}
		int Timer;
        public override void AI() {
			Timer++;
			//if (Timer % 5 == 0)
			//	Projectile.velocity.Y -= 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.velocity.Y = oldVelocity.Y * -0.85f;
            return false;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (Projectile.width == 10) {
				//Projectile.width *= 4;
				//Projectile.height *= 4;
				Projectile.position -= new Vector2(15, 15);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            Projectile.timeLeft = 2;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				Projectile.timeLeft = 2;
				if (Projectile.width == 10)
				{
					Projectile.position -= new Vector2(15, 15);
				}
			}
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