using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Misc
{
	public class BombRock : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Pocket Grenade");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Grenade);
			AIType = ProjectileID.Grenade;
			Projectile.width = 42;
			Projectile.height = 42;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
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
			target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 11)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP)
            {
				/*if (Projectile.width == 10)
				{
					Projectile.position -= new Vector2(15, 15);
				}*/
				Projectile.timeLeft = 2;
			}
			target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 11)*60);
        }

        public override void Kill(int timeLeft) {
			Projectile.width *= 4;
			Projectile.height *= 4;
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 20; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width/4, Projectile.height/4, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
		}
    }   
}