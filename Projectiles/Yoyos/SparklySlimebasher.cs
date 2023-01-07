using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Yoyos
{
	public class SparklySlimebasher : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 11f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 320f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 11.5f;
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(320, 60*Main.rand.Next(3, 6), false);
			if (target.type != NPCID.TargetDummy) for (int i = 0; i < Main.rand.Next(1, 4); i++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-12, -6)), ModContent.ProjectileType<SparklyGelFriendly>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
		}
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(320, 60*Main.rand.Next(3, 6), false);
			for (int i = 0; i < Main.rand.Next(1, 4); i++) ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-12, -6)), ModContent.ProjectileType<SparklyGelFriendly>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
        }
        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PinkSlime);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}