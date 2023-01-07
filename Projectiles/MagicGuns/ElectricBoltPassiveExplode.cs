using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Projectiles.MagicGuns
{
	public class ElectricBoltPassiveExplode : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electric Bolt");
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			AIType = ProjectileID.Bullet;
			switch (Projectile.ai[0]) {
				case 0f: Projectile.DamageType = DamageClass.Melee;
					return;
				case 1f: Projectile.DamageType = DamageClass.Ranged;
					return;
				case 2f: Projectile.DamageType = DamageClass.Magic;
					return;
				case 3f: Projectile.DamageType = DamageClass.Summon;
					return;
            }
			Projectile.ai[0] = 0f;
		}
		public override void AI() {
			if (++Projectile.frameCounter >= 4) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), ModContent.ProjectileType<ElectricBoltPassiveExplodeExp>(), (int)(Projectile.damage * 0.8f), 0.1f, Projectile.owner, 2f);
			SoundEngine.PlaySound(SoundID.Item96, Projectile.position);
		}
	}   
}