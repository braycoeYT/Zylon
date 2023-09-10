using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADDZapChase : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Diskite Zap");
        }
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = false;
			Projectile.alpha = 127;
		}
		Vector2 speed;
        public override void AI() {
			Projectile.rotation += 0.05f;
			Lighting.AddLight(Projectile.Center, 0.6f, 0.6f, 0.6f);
            if (Projectile.timeLeft > 60 && Projectile.timeLeft < 90) Projectile.velocity /= 2;
			if (Projectile.timeLeft == 60) {
				speed = Projectile.Center - Main.player[Main.npc[ZylonGlobalNPC.diskiteBoss].target].Center;
				speed.Normalize();
            }
			if (Projectile.timeLeft < 60) {
				Projectile.velocity -= speed;
            }
        }
		public override void PostAI() {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)	{
            target.AddBuff(BuffID.Electrified, Main.rand.Next(1, 4)*60);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}