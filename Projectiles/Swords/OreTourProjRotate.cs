using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class OreTourProjRotate : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ore Tour");
			Main.projFrames[Projectile.type] = 9;
        }
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.type == NPCID.EaterofWorldsBody) Projectile.penetrate = 0;
		}
        int Timer;
		bool dead;
		float rot;
        public override void AI() {
			if (dead) {
				Timer++;
				Projectile.penetrate = 1;
				Projectile.rotation += 0.04f;
				if (Timer > 20) Projectile.tileCollide = true;
				Projectile.velocity = new Vector2(0, -8).RotatedBy(MathHelper.ToRadians((360/9*Projectile.ai[1])+rot));
				return;
            }
			Projectile.frame = (int)Projectile.ai[1];
			rot += 2;
			Projectile main = Main.projectile[(int)Projectile.ai[0]];
			Projectile.rotation += 0.02f;
			Projectile.Center = main.Center - new Vector2(0, 32).RotatedBy(MathHelper.ToRadians((360/9*Projectile.ai[1])+rot));
			Projectile.alpha -= 17;
			if (main.active == false) dead = true;
        }
		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.HeartCrystal);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}