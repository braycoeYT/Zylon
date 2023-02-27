using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Ammo
{
	public class PocketGrenade : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pocket Grenade");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Grenade);
			AIType = ProjectileID.Grenade;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
		}
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            if (Projectile.width == 10) {
				//Projectile.width *= 4;
				//Projectile.height *= 4;
				Projectile.position -= new Vector2(15, 15);
            }
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
            if (Projectile.width == 10) {
				//Projectile.width *= 4;
				//Projectile.height *= 4;
				Projectile.position -= new Vector2(15, 15);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            Projectile.timeLeft = 2;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            Projectile.timeLeft = 2;
        }
        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			for (int i = 0; i < 10; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			for (int i = 0; i < 20; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X+60, Projectile.position.Y+30), Projectile.width/4, Projectile.height/4, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
		}
    }   
}