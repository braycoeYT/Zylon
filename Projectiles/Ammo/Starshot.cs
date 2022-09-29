using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class Starshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Starshot");
        }
		bool word;
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			Projectile.width = 16;
			Projectile.height = 16;
			if (Projectile.ai[0] == 1f)
				word = true;
			Projectile.ai[0] = 0f;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.Starshot>());
		}
	}   
}