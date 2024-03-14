using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Wands
{
	public class CryoWandProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Cryo Wand");
        }
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Magic;
			AIType = ProjectileID.Seed;
		}
		int Timer;
		float newRot;
        public override void AI() {
            Timer++;
			if (Timer % 6 == 0) Projectile.velocity.Y += 1;
        }
        public override void PostAI() {
            newRot += 0.08f;
			Projectile.rotation = newRot;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8)*60);
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 8) * 60);
			}
        }

        public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Shatter, Projectile.Center);
			Vector2 newVel = Projectile.velocity*-1f;
			newVel.Normalize();
			newVel *= 6.25f;
			if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 3; i++) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, newVel.RotatedByRandom(2f), ModContent.ProjectileType<CryoWandProjShard>(), (int)(Projectile.damage*0.5f), Projectile.knockBack*0.5f, Projectile.owner);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}