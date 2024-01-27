using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Yoyos
{
	public class GloriousSun : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Glorious Sun");
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 375f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;
		}
		public override void SetDefaults() {
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
		}
		int Timer;
		float rot;
		public override void AI() {
			Timer++;
			rot += 0.5f;
			if (Timer % 10 == 0) for (int x = 0; x < 4; x++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 150).RotatedBy(MathHelper.ToRadians(rot+x*90)), Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, Projectile.damage, 0, Projectile.owner);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Daybreak, 180);
		}
	}
}