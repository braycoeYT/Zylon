using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class BoneFriendlyMagic : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bone");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bone);
			AIType = ProjectileID.Bone;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            if (target.type == NPCID.WallofFleshEye || target.type == NPCID.WallofFlesh)
				damage = (int)(damage * 0.65f);
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}