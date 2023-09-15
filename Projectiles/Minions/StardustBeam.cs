using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Minions
{
	public class StardustBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Stardust Beam");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Summon;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.aiStyle = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
		}
        public override void AI() {
            //Projectile.velocity *= 1.01f;
			//Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Microsoft.Xna.Framework.Vector2(), ProjectileID.LunarFlare, Projectile.damage, Projectile.knockBack, Projectile.owner);
		}
	}   
}