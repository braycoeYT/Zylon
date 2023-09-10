using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class AridBoStaff : SpearProj
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Arid Bo Staff");
		}
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 54;
            Projectile.height = 54;
        }
        public AridBoStaff() : base(0f, 20, 360f, 10f, 2, 30, 60f, 0f, 1.5f, true, true, false) { }

		public override void SpearInThrustSwing()
		{
			if (Duration == (ThrustFrames / 4))
			{
				for (int i = 0; i < 6; i++)
				{
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame);
					dust.noGravity = true;
					dust.scale = 1.2f;
					dust.velocity = Projectile.velocity * 8f;
				}
				if (Main.myPlayer == Projectile.owner)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, (Projectile.velocity * Main.rand.NextFloat(10f, 15f)).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-1f, 1f))), ModContent.ProjectileType<AridBoStaffProj>(), Projectile.damage, 2f, Main.myPlayer);
				}
			}
		}

		public override void PostAI()
		{
			if (SwingNumber >= 0 && SwingNumber <= 1)
			{
				float SwingMulti = -1;
				if (SwingNumber == 1)
					SwingMulti = 1;

				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = (Projectile.velocity * 7f).RotatedBy(MathHelper.ToRadians((MathHelper.SmoothStep((RadianSwingRotation / 2f), ((RadianSwingRotation / 2f) * -1f), Duration / (float)RadianSwingFrames) * SwingMulti)));

				Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame);
				dust2.noGravity = true;
				dust2.scale = 1f;
				dust2.velocity = (Projectile.velocity * 7f).RotatedBy(MathHelper.ToRadians((MathHelper.SmoothStep((RadianSwingRotation / 2f), ((RadianSwingRotation / 2f) * -1f), Duration / (float)RadianSwingFrames) * (SwingMulti * -1))));
			}

			if (SwingNumber == 2 && Main.rand.NextBool(2))
            {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}

	}
}