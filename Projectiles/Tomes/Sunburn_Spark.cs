using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class Sunburn_Spark : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 1;
			Projectile.extraUpdates = 3;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			if (info.PvP) {
				target.AddBuff(BuffID.OnFire, Main.rand.Next(3, 9)*60);
			}
        }
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        public override void PostAI() {
            for (int i = 0; i < Main.rand.Next(1, 3); i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.scale = 1.75f;
			}
        }
        public override void Kill(int timeLeft) {
			if (Main.myPlayer == Projectile.owner) for (int x = 0; x < Main.rand.Next(3, 5); x++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-6, -2)), ModContent.ProjectileType<Sunburn_Flame>(), Projectile.damage/3, 0f, Main.myPlayer);
            }
		}
	}   
}