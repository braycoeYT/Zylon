using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Minions
{
	public class MiniJellyLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Mini Jelly Laser");
		}
		public override void SetDefaults() {
			Projectile.height = 290;
			Projectile.width = 6;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 10 + (int)(Projectile.ai[1] / 1.5f);
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 4 + (int)(Projectile.ai[1] / 10);
			Projectile.tileCollide = false;
		}
		bool a;
		public override void AI(){
			if (!a) {
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
				Projectile.position += Projectile.velocity;
				Projectile.velocity = new Vector2(0, 0);
				a = true;
				SoundEngine.PlaySound(SoundID.Item33);
			}
		}
	}
}