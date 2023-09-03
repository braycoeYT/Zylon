using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ADD_SpikeRingFriendly : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spike Ring");
		}
		public sealed override void SetDefaults() {
			Projectile.width = 144;
			Projectile.height = 144;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.aiStyle = -1;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.knockBackResist > 0f && target.boss == false) {
				Vector2 vector1;
				vector1 = target.Center - Projectile.Center;
				vector1.Normalize();
				target.velocity = vector1*12f;
			}
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (info.PvP)
			{
				if (!target.noKnockback)
				{
					Vector2 vector1;
					vector1 = target.Center - Projectile.Center;
					vector1.Normalize();
					target.velocity = vector1 * 12f;
				}
			}
        }

        public override void AI() {
            ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
			if (!p.ADDExpert) Projectile.timeLeft = 0;
			Projectile.Center = Main.player[Projectile.owner].Center;
			Projectile.rotation += 0.05f;
			Projectile.direction = Main.player[Projectile.owner].direction;
			Projectile.velocity = Vector2.Zero;
        }
    }
}