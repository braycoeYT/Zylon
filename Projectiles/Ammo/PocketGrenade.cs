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
				Projectile.width *= 4;
				Projectile.height *= 4;
				Projectile.position -= new Vector2(15, 15);
            }
        }
        public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
            if (Projectile.width == 10) {
				Projectile.width *= 4;
				Projectile.height *= 4;
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
			// If we are the original Projectile, spawn the 5 child Projectiles
			// Play explosion sound
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 80; i++) {
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}
			// Large Smoke Gore spawn
			for (int g = 0; g < 2; g++) {
				int goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), new Vector2(Projectile.position.X + (float)(Projectile.width / 2) - 24f, Projectile.position.Y + (float)(Projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
		}
    }   
}