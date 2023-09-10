using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Swords
{
	public class SlimeblastLarge : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Large Slimeblast");
        }
		public override void SetDefaults() {
			Projectile.width = 68;
			Projectile.height = 68;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 30;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.light = 1f;
			AIType = ProjectileID.Bullet;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Slimed, 300, false);
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Slimed, 300, false);
			}
        }

        int num = Main.rand.Next(5, 9);
		public override void AI() {
			Projectile.rotation += 0.05f;
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < num; i++) {
				ProjectileHelpers.NewNetProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, new Vector2(0, 15).RotatedByRandom(MathHelper.TwoPi), ModContent.ProjectileType<Slimeblast>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}