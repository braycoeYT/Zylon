using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.Chat;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class PlanteraElementalGel : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Elemental Goop Core");
        }
		public override void SetDefaults() {
			Projectile.width = 120;
			Projectile.height = 120;
			Projectile.tileCollide = false;
		}
		int Timer;
		float rot;
        public override void AI() {
            Timer++;

			if (Timer % 30 <= 9)
				Lighting.AddLight(Projectile.Center, 5f, 0f, 0f);
			else if (Timer % 30 <= 19)
				Lighting.AddLight(Projectile.Center, 0f, 5f, 0f);
			else
				Lighting.AddLight(Projectile.Center, 0f, 0f, 5f);

			Projectile.rotation += rot;
			if (Timer >= 60)
				rot += 0.003f;
			if (Timer >= 360 && Timer % 5 == 0)
				Projectile.velocity.Y -= 1;
			if (Timer == 480) {
				if (Main.netMode == NetmodeID.Server) {
				    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Slimes around the world begin to fuse!"), new Color(18, 222, 123));
				}
				else {
				    Main.NewText("Slimes around the world begin to fuse!", 18, 222, 123);
				}
				Projectile.active = false;
            }
        }
    }   
}