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
			Projectile.DamageType = DamageClass.Melee;
		}
		int Timer;
		float rot;
		public override void AI() {
			Timer++;
			rot += 3f;
			Lighting.AddLight(Projectile.Center, Color.Orange.ToVector3() * 0.5f);

			int yes = 0;
			if (Timer % 8 == 0) yes = 1;

			if (Timer % 2 == 0) for (int x = 0; x < 4; x++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 40).RotatedBy(MathHelper.ToRadians(rot+x*90)), Vector2.Zero, ModContent.ProjectileType<GloriousSunProj>(), Projectile.damage, 0, Projectile.owner, yes);
			if (Timer % 2 == 0) for (int x = 0; x < 8; x++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 80).RotatedBy(MathHelper.ToRadians((rot/2)+x*45)), Vector2.Zero, ModContent.ProjectileType<GloriousSunProj>(), Projectile.damage, 0, Projectile.owner);
			//if (Timer % 10 == 0) for (int x = 0; x < 12; x++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(0, 96).RotatedBy(MathHelper.ToRadians((rot/4)+x*30)), Vector2.Zero, ModContent.ProjectileType<GloriousSunProj>(), Projectile.damage, 0, Projectile.owner);
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