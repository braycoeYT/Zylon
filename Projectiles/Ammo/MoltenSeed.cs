using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class MoltenSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Molten Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ItemID.Seed);
		}
	}   
}