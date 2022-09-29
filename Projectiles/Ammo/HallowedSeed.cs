using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Ammo
{
	public class HallowedSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hallowed Seed");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
			Projectile.penetrate = 3;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.NextBool(2))
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position - new Vector2(0, 400), new Vector2(Main.rand.NextFloat(-1f, 1f), 12), ProjectileID.HallowStar, (int)(damage * 0.75f), Projectile.knockBack * 0.5f, Main.myPlayer);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            if (Main.rand.NextBool(2))
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.position - new Vector2(0, 400), new Vector2(Main.rand.NextFloat(-1f, 1f), 12), ProjectileID.HallowStar, (int)(damage * 0.75f), Projectile.knockBack * 0.5f, Main.myPlayer);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.CorruptSeed>());
		}
	}   
}