using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Pets
{
	public class DS_91Pet : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("DS-91");
            Main.projPet[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
            Projectile.width = 36;
            Projectile.height = 36;
        }
        int Timer;
        public override bool PreAI() {
            Timer++;
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            Projectile.tileCollide = Timer % 600 >= 420;
            if (Timer % 600 >= 420) {
                if (Timer % 5 == 0) Projectile.velocity.Y += 1;
                Projectile.rotation += 0.08f;
            }
            if (!player.dead && player.HasBuff<Buffs.Pets.DS_91Pet>())
                Projectile.timeLeft = 2;
            return Timer % 600 < 420;
        }
        public override void AI() {
            //Projectile.spriteDirection = Projectile.direction;
            // + MathHelper.PiOver2;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void PostAI() {
            Projectile.spriteDirection = 0;
            if (Timer % 600 >= 420 || (Timer % 2 == 0 && Timer % 600 >= 360)) Projectile.frame = 1;
            else Projectile.frame = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			if (Projectile.velocity.X != oldVelocity.X) {
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y) {
				Projectile.velocity.Y = -oldVelocity.Y;
			}
            Projectile.velocity *= 0.8f;
			return false;
		}
    }   
}