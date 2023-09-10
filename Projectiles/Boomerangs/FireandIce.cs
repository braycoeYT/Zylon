using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Boomerangs
{
	public class FireandIce : BoomerangProj
	{
		public FireandIce() : base(30, 6, 7, 30f, 400f, 35) { }

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fire and Ice");
        }
		public override void BoomerangDefaultsSafe() {
			Projectile.width = 38;
			Projectile.height = 38;
		}

		public override void OnHitNPCSafe(NPC target, int damage, float knockback, bool crit)
		{
			if (crit || Main.rand.NextBool(5))
            {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 8) * 60);
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8) * 60);
			}
		}
		public override void OnHitPvpSafe(Player target, int damage, bool crit)
		{
			if (crit || Main.rand.NextBool(5))
            {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 8) * 60);
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8) * 60);
			}
		}
        public override void BoomerangPeakArc()
        {
			if (Projectile.owner == Main.myPlayer)
            {
				for (int i = 0; i < 3; i++)
				{
					int projType = ModContent.ProjectileType<FireandIce_1>();
					if (Main.rand.NextBool(2)) projType = ModContent.ProjectileType<FireandIce_2>();
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.Next(-8, -4)), projType, (int)(Projectile.damage * 0.75f), Projectile.knockBack * 0.75f, Main.myPlayer);
				}
			}
		}

    }   
}