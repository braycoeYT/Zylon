using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class ElementalGooshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Gooshot");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Seed);
			AIType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.ShadowFlame, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.ShadowFlame, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(5, 11), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .1f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.ElementalGooshot>());
		}
	}   
}