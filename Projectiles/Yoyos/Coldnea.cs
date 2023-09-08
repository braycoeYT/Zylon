using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class Coldnea : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 290f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13.6f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(5, 11));
		}
        public override void OnHitPvp(Player target, int damage, bool crit) {
        target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(5, 11));
		}
		public override void SetDefaults() {
			Projectile.extraUpdates = 0;
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.MeleeNoSpeed;
		}
		int Timer;
		int spin;
        public override void AI() {
            Timer++;
			if (Timer % 5 == 0 && Timer > 20) {
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(spin)), ModContent.ProjectileType<IceLaser>(), Projectile.damage, Projectile.knockBack / 2, Main.myPlayer);
				spin += 15;
            }
        }
    }
}