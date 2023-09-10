using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class OreTourProjCenter : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Ore Tour");
        }
        public override void SetDefaults() {
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.aiStyle = -1;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 360;
			Projectile.ignoreWater = true;
		}
		bool init;
        public override void AI() {
			if (!init) {
				for (int i = 0; i < 9; i++)
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(), ModContent.ProjectileType<OreTourProjRotate>(), (int)(Projectile.damage*0.75f), Projectile.knockBack/3, Projectile.owner, Projectile.whoAmI, i);
				init = true; //remove this for absolute chaos
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}