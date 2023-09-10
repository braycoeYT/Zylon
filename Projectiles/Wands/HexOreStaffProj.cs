using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Wands
{
	public class HexOreStaffProj : ModProjectile
	{
        public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Hexed Ore Staff");
=======
			// DisplayName.SetDefault("Hexed Ore Staff");
>>>>>>> ProjectClash
        }
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 6;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.ignoreWater = true;
		}
        public override void AI() {
            for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.myPlayer == Projectile.owner)
				for (int x = 0; x < 3; x++)
					Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center, new Vector2(0, 30).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<Projectiles.Wands.HexOreStaffProj_Child>(), (int)(Projectile.damage*0.2f), Projectile.knockBack*0.2f, Projectile.owner);
		}
	}   
}