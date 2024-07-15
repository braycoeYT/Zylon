using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Accessories
{
	public class TribalCharmProjFall : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.ignoreWater = true;
			Projectile.alpha = 255;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.DeadlyToxins>(), Main.rand.Next(3, 7)*60);
        }
        float targetY;
		bool init;
        public override void AI() {
			Projectile.alpha -= 17;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (!init) {
				Projectile.velocity = Projectile.Center.DirectionTo(Main.npc[(int)Projectile.ai[0]].Center)*Main.rand.NextFloat(12f, 18f);
				targetY = (int)Main.npc[(int)Projectile.ai[0]].Center.Y;
				init = true;
			}
			Projectile.tileCollide = Projectile.Center.Y > targetY-16;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}