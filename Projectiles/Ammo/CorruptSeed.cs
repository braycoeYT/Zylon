using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class CorruptSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Corrupt Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = 3;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            Projectile.damage += 4;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            Projectile.damage += 4;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.CorruptSeed>());
		}
	}   
}