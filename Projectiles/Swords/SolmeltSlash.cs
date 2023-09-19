using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class SolmeltSlash : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults() {
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 42;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
			Projectile.tileCollide = true;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
			}
        }
		public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
		int Timer;
        public override void AI() {
			if (++Projectile.frameCounter >= 7) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 6)
					Projectile.frame = 0;
			}
			Timer++;
            if (Timer == 15) {
				if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center - new Microsoft.Xna.Framework.Vector2(0, 40*Projectile.ai[0]), Microsoft.Xna.Framework.Vector2.Zero, ModContent.ProjectileType<SolmeltSlash>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, Projectile.ai[0]);
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}