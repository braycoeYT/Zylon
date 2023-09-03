using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Ammo
{
	public class SlimeArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Slime Arrow");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = 1;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Slimed, 60 * Main.rand.Next(3, 6), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Slimed, 60 * Main.rand.Next(3, 6), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Main.rand.NextFloat() < .25f) Item.NewItem(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.getRect(), ModContent.ItemType<Items.Ammo.SlimeArrow>());
		}
	}   
}