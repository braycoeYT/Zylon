using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class ObsidianDart : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Obsidian Dart");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.ObsidianDart>());
		}
	}   
}