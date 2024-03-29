using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Projectiles.Blowpipes
{
	public class MeteorLauncherProj : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Meteor Launcher");
			Main.projFrames[Projectile.type] = 5;
        }
        public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 2 + (int)Projectile.ai[0];
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.scale = 1f + Projectile.ai[0]*0.1f;
		}
        public override void AI() {
            Projectile.velocity *= 1.008f;
			Projectile.rotation += 0.1f + Projectile.ai[0]*0.02f;
			Projectile.frame = (int)Projectile.ai[0];
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(5, 11), false);
		}
        public override void OnKill(int timeLeft) {
			for (int i = 0; i < (int)Projectile.ai[0]*2; i++) {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<MeteorLauncherProjFire>(), (int)(Projectile.damage*0.2f), Projectile.knockBack*0.25f, Projectile.owner);
            }
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.Center);
		}
	}   
}