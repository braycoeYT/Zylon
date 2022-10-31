using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Chat;

namespace Zylon.Projectiles.Bosses.Dirtball
{
	public class DBSpirit : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Forest Spirit");
        }
		public override void SetDefaults() {
			Projectile.width = 80;
			Projectile.height = 80;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 600;
		}
		int Timer;
		int int1;
        public override void AI() {
            Timer++;
			Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
			if (Timer >= 120 && Timer % 5 == 0)
				int1 += 1;
			Projectile.velocity = new Vector2(0, int1).RotatedByRandom(1.6f);//.RotatedBy(MathHelper.ToRadians(Timer+60));
        }
        public override void PostAI() {
			for (int i = 0; i < 6; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 56);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 2f + Main.rand.Next(-30, 31) * 0.01f;
			}
        }
    }   
}