using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class MudslingerProj_3 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Molten Mud");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 120;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 0.5f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 5));
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 5));
        }
		public override void AI() {
			Projectile.velocity *= 1.02f;
			//Projectile.friendly = Projectile.timeLeft < 105;
			Projectile.rotation += 0.1f;
			Lighting.AddLight(Projectile.Center, 0.25f, 0f, 0f);
		}
		public override void PostAI() {
			int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
		}
	}   
}