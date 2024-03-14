using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles
{
	public class BoneFriendlyMagic : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bone");
        }
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Bone);
			AIType = ProjectileID.Bone;
			Projectile.DamageType = DamageClass.Magic;
		}
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (target.type == NPCID.WallofFleshEye || target.type == NPCID.WallofFlesh)
				modifiers.FinalDamage *= 0.65f;
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}