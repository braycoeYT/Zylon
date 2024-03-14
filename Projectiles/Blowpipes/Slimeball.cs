using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Blowpipes
{
	public class Slimeball : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Slimeball");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = 1;
			Projectile.scale = 1f;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 15;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		    target.AddBuff(BuffID.Slimed, 60*Main.rand.Next(3, 6));
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Slimed, 60 * Main.rand.Next(3, 6));
			}
        }

        bool init;
		int Timer;
		public override void AI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (!init) {
				Projectile.penetrate = (int)(1+Projectile.ai[0]*1.5f);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(), ModContent.ProjectileType<Slimeball_Deco>(), 0, 0f, Main.myPlayer, Projectile.whoAmI, Projectile.ai[0]/1.5f);
				init = true;
            }
			Timer++;
			Projectile.width = (int)(28*Projectile.ai[0]/1.5f);
			Projectile.height = (int)(28*Projectile.ai[0]/1.5f);
			//Projectile.scale = Projectile.ai[0]/1.5f;
			//if (Projectile.scale < 0.25f) Projectile.scale = 0.25f;
			Projectile.tileCollide = Timer > (int)(5f*Projectile.ai[0]);
		}
		public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}