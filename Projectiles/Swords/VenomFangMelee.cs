using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class VenomFangMelee : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Venom Fang");
        }
		public override void SetDefaults() {
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 28;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.DamageType = DamageClass.Melee;
		}
        public override void PostAI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(5, 8)*60);
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Venom, Main.rand.Next(5, 8)*60);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}