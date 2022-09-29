using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Ammo
{
	public class BloodiedArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bloodied Arrow");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 4;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .25f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.BloodiedArrow>());
		}
	}   
}