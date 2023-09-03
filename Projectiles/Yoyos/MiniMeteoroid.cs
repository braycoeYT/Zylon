using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Yoyos
{
	public class MiniMeteoroid : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 5.5f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 240f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 11.25f;
		}
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.DamageType = DamageClass.Melee;
		}
		int counter;
		int counter2;
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			counter++;
			target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 6), false);
			if (counter >= 3) {
				while (counter2 < 8) {
					counter2++;
					ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Microsoft.Xna.Framework.Vector2(Main.rand.Next(-20, 21), Main.rand.Next(-20, 21)), new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<MiniMiniMeteoroid>(), (int)(Projectile.damage*0.75f), Projectile.knockBack*0.75f, Projectile.owner);
				}
			}
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				counter++;
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(3, 6), false);
				if (counter >= 3)
				{
					while (counter2 < 8)
					{
						counter2++;
						ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Microsoft.Xna.Framework.Vector2(Main.rand.Next(-20, 21), Main.rand.Next(-20, 21)), new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<MiniMiniMeteoroid>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack * 0.75f, Projectile.owner);
					}
				}
			}
        }

        public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Meteorite);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
    }
}