using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class Kivasana : SpearProj
	{
        public override void SpearDefaultsSafe()
        {
			Projectile.width = 88;
			Projectile.height = 88;
			Projectile.localNPCHitCooldown = 50;
		}

		public Kivasana() : base(-33f, 44, 27.8f, 85f, 4, 50, 100f, 0f, 3.5f, false, false, false) { }

		public override void SpearOnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Midas, Main.rand.Next(10, 21) * 60);
		}
        public override void SpearOnHitPVP(Player target, int damage)
        {
			target.AddBuff(BuffID.Midas, Main.rand.Next(10, 21) * 60);
		}
		public override void PostAI() {
			if (Main.rand.NextBool(2)) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Gold);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}