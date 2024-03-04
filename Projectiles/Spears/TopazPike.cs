using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.Spears
{
	public class TopazPike : SpearProj
	{
        public override void SpearDefaultsSafe()
        {
            Projectile.width = 80;
            Projectile.height = 80;
        }
        public TopazPike() : base(-23f, 20, 25f, 65f, 2, 20, 80f, 0f, 1.5f, false, false, false) { }
		public override void SpearInThrustSwing()
        {
			if (Duration == (ThrustFrames / 2) && Main.myPlayer == Projectile.owner)
			{
				SoundEngine.PlaySound(SoundID.Item43, Projectile.Center);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity*12f, ModContent.ProjectileType<TopazPikeProj>(), (int)(Projectile.damage*0.8f), 2f, Main.myPlayer);
			}
		}
		public override void PostAI()
		{
			if (Main.rand.NextBool(2))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
				dust.scale = 1f;
				dust.velocity = Projectile.velocity * 3f;
			}
		}

	}
}