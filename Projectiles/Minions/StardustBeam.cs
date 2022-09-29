using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Minions
{
	public class StardustBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stardust Beam");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bullet);
			AIType = ProjectileID.Bullet;
			Projectile.DamageType = DamageClass.Summon;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Microsoft.Xna.Framework.Vector2(), 645, Projectile.damage, Projectile.knockBack, Main.myPlayer);
		}
	}   
}