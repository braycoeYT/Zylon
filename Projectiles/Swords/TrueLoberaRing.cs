using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class TrueLoberaRing : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.friendly = false;
		}
		bool init;
        public override void AI() {
			if (!init && Main.myPlayer == Projectile.owner) {
				for (int i = 0; i < 4; i++)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<TrueLoberaOrb>(), (int)(Projectile.damage*0.5f), Projectile.knockBack/2, Projectile.owner, Projectile.whoAmI, i);
				init = true;
			}
        }
    }   
}