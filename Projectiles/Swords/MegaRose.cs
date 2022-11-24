using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Swords
{
	public class MegaRose : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blossomed Rose");
        }
		public override void SetDefaults() {
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 180;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            Projectile.velocity *= 0.5f;
			if (Projectile.timeLeft > 60)
				Projectile.timeLeft -= 30;
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            Projectile.velocity *= 0.5f;
			if (Projectile.timeLeft > 60)
				Projectile.timeLeft -= 30;
        }
        public override void AI() {
			Projectile.rotation += (0.06f*Projectile.ai[0])+0.04f;
            Projectile.velocity *= 0.975f;
			if (Projectile.timeLeft == 30) {
				int type = ProjectileID.SporeCloud;
				int damage = Projectile.damage;
				if (Projectile.ai[0] == 1) {
					type = ModContent.ProjectileType<MiniRose>();
					damage = (int)(damage*0.25f);
				}
				int j = 0;
				for (int i = 0; i < 8; i++) {
					if (Projectile.ai[0] == 1) j = i;
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -16).RotatedBy(MathHelper.ToRadians(i*45)), type, damage, Projectile.knockBack, Main.myPlayer, j);
				}
			}
			if (Projectile.timeLeft <= 20) Projectile.alpha += 17;
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}