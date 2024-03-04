using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class AmaguqProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 290f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.5f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(5, 11));
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 60*Main.rand.Next(4, 8));
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Frostburn, 60*Main.rand.Next(5, 11));
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 60*Main.rand.Next(4, 8));
		}
		public override void SetDefaults() {
			Projectile.extraUpdates = 0;
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
		}
		int Timer;
        public override void AI() {
            Timer++;
			if (Timer % 5 == 0) { //If you hold the yoyo still for a while, projectiles eventually stop moving or spawning, and idk why?
				Vector2 newVel = Vector2.Normalize(Projectile.velocity);
				if (newVel == Vector2.Zero) newVel = new Vector2(0, 1).RotatedByRandom(MathHelper.TwoPi); //doesn't fix --> || (Math.Abs(newVel.X) + Math.Abs(newVel.Y) < 0.1f)
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, newVel.RotatedByRandom(MathHelper.Pi), ModContent.ProjectileType<AmaguqTrail>(), Projectile.damage/2, Projectile.knockBack/2, Projectile.owner);
            }
        }
    }
}