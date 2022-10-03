using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Wands
{
	public class ManaSiphonBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mana Siphon");
        }
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.alpha = 255;
			Projectile.light = 0.5f;
		}
        public override void AI() {
            for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.WhiteDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			int healingAmount = Main.rand.Next(5, 8);
			Main.player[Projectile.owner].statMana += healingAmount;
			Main.player[Projectile.owner].ManaEffect(healingAmount);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            int healingAmount = Main.rand.Next(5, 8);
			Main.player[Projectile.owner].statMana += healingAmount;
			Main.player[Projectile.owner].ManaEffect(healingAmount);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}