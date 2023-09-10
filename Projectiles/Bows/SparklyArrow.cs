using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bows
{
	public class SparklyArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sparkly Arrow");
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
			target.AddBuff(320, 60 * Main.rand.Next(3, 6), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(320, 60 * Main.rand.Next(3, 6), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 3; i++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 6), new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(8, 13)), ModContent.ProjectileType<SparklyGelFriendly>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner, 1f);
		}
	}   
}