using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class MidpointBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Midpoint");
        }
		public override void SetDefaults() {
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.light = 0.25f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (Projectile.ai[0] % 5 == 0) target.AddBuff(BuffID.OnFire, Main.rand.Next(8, 16)*60);
			if (Projectile.ai[0] % 5 == 1) target.AddBuff(BuffID.CursedInferno, Main.rand.Next(8, 16)*60);
			if (Projectile.ai[0] % 5 == 3) target.AddBuff(BuffID.Ichor, Main.rand.Next(8, 16)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Projectile.ai[0] % 5 == 0) target.AddBuff(BuffID.OnFire, Main.rand.Next(8, 16)*60);
			if (Projectile.ai[0] % 5 == 1) target.AddBuff(BuffID.CursedInferno, Main.rand.Next(8, 16)*60);
			if (Projectile.ai[0] % 5 == 3) target.AddBuff(BuffID.Ichor, Main.rand.Next(8, 16)*60);
        }
        public override void AI() {
			if (Projectile.ai[0] % 5 == 1) Projectile.velocity *= 1.035f;
			if (Projectile.ai[0] % 5 == 2) {		
				Projectile.penetrate = 9999;
				Projectile.width = 20;
				Projectile.height = 20;
			}
			if (Projectile.ai[0] % 5 == 3) {		
				Projectile.velocity *= 0.988f;
				if (Projectile.timeLeft > 480) Projectile.timeLeft = 480;
			}
			int whatDust = 6; //orange
			if (Projectile.ai[0] % 5 == 1) whatDust = 75; //green
			if (Projectile.ai[0] % 5 == 2) whatDust = 135; //cyan
			if (Projectile.ai[0] % 5 == 3) whatDust = 64; //yellow
			if (Projectile.ai[0] % 5 == 4) whatDust = 73; //pink
            for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, whatDust);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			if (Projectile.ai[0] % 5 == 4) for (int i = 0; i < 6; i++)
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*60)), ModContent.ProjectileType<MidpointBolt2>(), (int)(Projectile.damage * 0.65f), Projectile.knockBack / 2, Main.myPlayer);
		}
	}   
}