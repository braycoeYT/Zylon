using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class MegaRose : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blossomed Rose");
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void AI() {
			Projectile.rotation += 0.04f;
            Projectile.velocity *= 0.975f;
			if (Projectile.timeLeft == 30)
				for (int i = 0; i < 8; i++)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -16).RotatedBy(MathHelper.ToRadians(i*45)), ProjectileID.SporeCloud, Projectile.damage, Projectile.knockBack, Main.myPlayer);
			if (Projectile.timeLeft <= 20) Projectile.alpha += 17;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}