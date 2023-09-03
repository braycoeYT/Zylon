using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Guns
{
	public class ClockworkBit : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (!target.boss && target.type != NPCID.GolemHead && target.type != NPCID.SkeletronHand && Main.rand.NextFloat() < .2f) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(1, 4)*60);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
			if (info.PvP)
            {
				if (Main.rand.NextFloat() < .1f) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(1, 3) * 60);
			}
        }

        public override void AI() {
            Projectile.rotation += 0.1f;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}