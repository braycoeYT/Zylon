using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Pets
{
	public class SpookyJellyfish : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Spooky Jellyfish");
            Main.projPet[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
            Projectile.width = 28;
            Projectile.height = 28;
        }
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            return true;
        }
        int Timer;
        int alph;
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.Pets.SpookyJellyfish>())
                Projectile.timeLeft = 2;
        }
        public override void PostAI() {
            Projectile.spriteDirection = 0;
            Timer++;
            if (Projectile.frame > 1) Projectile.frame = 0;
            if (Timer % 360 >= 270)
                alph += 15;
            else alph -= 15;
            if (alph > 255) alph = 255;
            if (alph < 0) alph = 0;
            Projectile.alpha = alph;

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
    }   
}