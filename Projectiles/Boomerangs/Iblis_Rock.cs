using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Boomerangs
{
	public class Iblis_Rock : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.usesIDStaticNPCImmunity = true;
			Projectile.idStaticNPCHitCooldown = 10;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6)*60);
			}
        }
        public override void AI() {
			Projectile.ai[0]++;
			if (Projectile.ai[0] % 2 == 0) Projectile.velocity.Y += 1;
        }
        public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (oldVelocity.Y < 0) { Projectile.velocity.Y = oldVelocity.Y*-1.5f; return false; }
			return true;
        }
	}   
}