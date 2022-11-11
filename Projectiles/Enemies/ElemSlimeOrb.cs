using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Enemies
{
	public class ElemSlimeOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Slime Orb");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 34;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 420;
			Projectile.tileCollide = false;
			Projectile.frame = Main.rand.Next(2);
		}
        public override void AI() {
            Projectile.velocity *= 0.97f;
        }
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.ElemDust>());
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Poisoned, Main.rand.Next(10, 21)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f) target.AddBuff(BuffID.Poisoned, Main.rand.Next(10, 21)*60);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}